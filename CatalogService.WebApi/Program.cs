using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Mappings;
using System.Reflection;
using CatalogService.Application;
using CatalogService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using CatalogService.Application.Consumers;
using CatalogService.Application.LinqSpecs.Factory;
using CatalogService.Domain.Aggregates.BookAggregate;
using CatalogService.Infrastructure.Repositories;
using CatalogService.Domain.Aggregates.AuthorAggregate;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISpecFactory<Book>, BookSpecFactory>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ICatalogServiceContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<CatalogServiceContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<BookReservedConsumer>();
    busConfigurator.AddConsumer<OrderClosedConsumer>();    
    busConfigurator.AddActivities(typeof(Program).Assembly);

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", h => {
            h.Username("guest");
            h.Password("guest");
        });
        configurator.ConfigureEndpoints(context);

    });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetService<CatalogServiceContext>();
    
}
app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "CatalogService API");
});
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "catalog",
     pattern: "{controller}/{action=Index}/{id?}");
app.Map("", () => Results.Redirect("/api"))
    .RequireRateLimiting("fixed");

app.Run();
