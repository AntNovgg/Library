using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Infrastructure.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.BookTittle)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(order => order.Comment)
                .IsRequired()
                .HasMaxLength(250);

            builder.OwnsOne(order => order.AuthorFullName, authorFullName =>
            {
                authorFullName.Property(a => a.Name).IsRequired().HasMaxLength(100);
                authorFullName.Property(a => a.LastName).IsRequired().HasMaxLength(100);
                authorFullName.Property(a => a.MiddleName).HasMaxLength(100);
            });

            builder.HasOne(order => order.Renter)
                .WithMany()
                .HasForeignKey(order => order.RenterId);

            //builder.HasKey(renter => renter.Id);
            //builder.Property(renter => renter.BookTittle)
            //    .IsRequired()
            //    .HasMaxLength(250);
            //builder.OwnsOne(o => o.AuthorFullName)                
            //builder.Property(renter => renter.Comment)
            //    .IsRequired()
            //    .HasMaxLength(250);
            //builder.HasOne(o => o.Renter)
            //.WithMany()
            //.HasForeignKey(o => o.RenterId);
        }
    }
}
