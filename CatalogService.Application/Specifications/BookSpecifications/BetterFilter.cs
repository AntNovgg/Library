using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public class BetterFilter : IFilter<Book>
    {
        public IEnumerable<Book> Filter(IEnumerable<Book> items,
            Specification<Book> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }
}
