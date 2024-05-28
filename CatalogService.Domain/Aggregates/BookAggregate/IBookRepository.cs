using CatalogService.Domain.Seeds;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Aggregates.BookAggregate
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Add(Book book);

        void Update(Book book);

        Task<Book> GetAsync(Guid bookId);
        Task<IEnumerable<Book>> ListAllAsync();
        Task<IEnumerable<Book>> ListAll(Specification<Book> spec);
        void Delete(Book book);

    }
}
