using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.LinqSpecs.OrderSpecs
{
    public class DefaultSpec : Specification<Order>
    {
        public override Expression<Func<Order, bool>> ToExpression()
        {
            return t => true;
        }
    }
}
