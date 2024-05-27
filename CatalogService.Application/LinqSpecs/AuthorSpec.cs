using CatalogService.Domain.Aggregates.BookAggregate;
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
        public Guid AuthorId { get; set; }

        public AuthorSpec(Guid authorId)
        {
            AuthorId = authorId;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return t => t.AuthorId == AuthorId;
        }
    }
}
