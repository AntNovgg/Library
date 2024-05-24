using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public class AvailabilitySpecification : Specification<Book>
    {
        private bool isAvailable;
        public AvailabilitySpecification(bool isAvailable)
        {
            this.isAvailable = isAvailable;
        }

        public override bool IsSatisfied(Book b)
        {
            return b.IsAvailable == isAvailable;
        }
    }
}
