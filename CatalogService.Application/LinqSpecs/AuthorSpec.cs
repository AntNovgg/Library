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
    public class AuthorSpec : Specification<Book>
    {
        public string Author { get; set; }

        public AuthorSpec(string author)
        {
            Author = author;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return t => t.Author == Author;
        }
    }
}
