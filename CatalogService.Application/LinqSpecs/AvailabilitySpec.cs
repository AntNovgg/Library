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
    public class AvailabilitySpec : Specification<Book>
    {
        public bool IsAvailable { get; set; }

        public AvailabilitySpec(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return t => t.IsAvailable == IsAvailable;
        }
    }
}
