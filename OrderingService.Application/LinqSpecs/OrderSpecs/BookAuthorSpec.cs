using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs.OrderSpecs
{
    public class BookAuthorSpec : Specification<Order>
    {
        public FullName AuthorFullName { get; set; }

        public BookAuthorSpec(FullName authorFullName)
        {
            AuthorFullName = authorFullName;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return t => t.AuthorFullName == AuthorFullName;
        }
    }
}
