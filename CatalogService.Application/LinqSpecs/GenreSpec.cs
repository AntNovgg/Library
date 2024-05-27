using CatalogService.Domain.Aggregates;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs
{
    public class GenreSpec : Specification<Book>
    {
        public Genre Genre { get; set; }

        public GenreSpec(Genre genre)
        {
            Genre = genre;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return t => t.BookGenre == Genre;
        }
    }
}
