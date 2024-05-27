using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Aggregates.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);            
            builder.Property(book => book.Tittle)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(book => book.AuthorId)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(book => book.BookGenre)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}

