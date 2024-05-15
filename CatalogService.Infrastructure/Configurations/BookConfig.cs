using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);            
            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(book => book.Author)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(book => book.Genre)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}

