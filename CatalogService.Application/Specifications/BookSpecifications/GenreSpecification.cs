using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public class GenreSpecification : Specification<Book>
    {
        private Genre genre;
        public GenreSpecification(Genre genre)
        {
            this.genre = genre;
        }

        public override bool IsSatisfied(Book b)
        {
            return b.BookGenre == genre;
        }
    }
    
}
