using OrderingService.Application.Common.Interfaces;
using OrderingService.Application.Common.Mappings;
using System.Reflection;
using OrderingService.Application;
using OrderingService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using OrderingService.Application.Consumers;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Infrastructure.Repositories;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Application.LinqSpecs.Factory;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IOrderingServiceContext).Assembly));
});
builder.Services.AddScoped<ISpecFactory<Order>, OrderSpecFactory>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRenterRepository, RenterRepository>();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<OrderingServiceContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<BookReservedFailedConsumer>();

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
    var context = service.GetService<OrderingServiceContext>();


}
app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "OrderingService API");
});
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "ordering",
    pattern: "{controller}/{action=Index}/{id?}");
app.Map("/", () => Results.Redirect("/api"))
    .RequireRateLimiting("fixed");

app.Run();
