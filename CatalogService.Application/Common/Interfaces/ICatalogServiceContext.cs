using CatalogService.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Common.Interfaces
{
    public interface ICatalogServiceContext
    {
        public DbSet<Book> Books { get; set; }
        void Migrate();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
