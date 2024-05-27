using CatalogService.Domain.Aggregates.AuthorAggregate;
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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CatalogServiceContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public AuthorRepository(CatalogServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Author Add(Author author)
        {
            return _context.Authors.Add(author).Entity;

        }

        public async Task<Author> GetAsync(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);

            return author;
        }

        public void Update(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
        }
        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
        }
    }
}
