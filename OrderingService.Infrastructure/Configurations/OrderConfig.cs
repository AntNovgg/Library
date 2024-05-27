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
            builder.HasKey(renter => renter.Id);
            builder.Property(renter => renter.BookTittle)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(renter => renter.BookAuthor)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(renter => renter.Comment)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasOne(o => o.Renter)
            .WithMany()
            .HasForeignKey(o => o.RenterId);
        }
    }
}
