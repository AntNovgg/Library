using CatalogService.Domain.Aggregates.BookAggregate;
using CatalogService.Domain.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly CatalogServiceContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public BookRepository(CatalogServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Book Add(Book book)
        {
            return _context.Books.Add(book).Entity;

        }

        public async Task<Book> GetAsync(Guid bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            return book;
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }
        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}
