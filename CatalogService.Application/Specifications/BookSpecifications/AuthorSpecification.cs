using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public class AuthorSpecification : Specification<Book>
    {
        private string author;
        public AuthorSpecification(string author)
        {
            this.author = author;
        }

        public override bool IsSatisfied(Book b)
        {
            return b.Author == author;
        }
    }
}
