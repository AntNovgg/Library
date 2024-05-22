using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderingService.Domain.Aggregates.RenterAggregate;

namespace OrderingService.Infrastructure.Configurations
{
    public class RenterConfig : IEntityTypeConfiguration<Renter>
    {
        public void Configure(EntityTypeBuilder<Renter> builder)
        {
            builder.HasKey(renter => renter.Id);
            builder.OwnsOne(renter => renter.RenterFullName);
            builder.OwnsOne(renter => renter.RenterAddress); 
            builder.Property(renter => renter.Telephone)
                .IsRequired()
                .HasMaxLength(250);

        }
    }
}

