using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public class DefaultSpecification : Specification<Book>
    {
        public override bool IsSatisfied(Book p)
        {
            return true;
        }
    }
}
