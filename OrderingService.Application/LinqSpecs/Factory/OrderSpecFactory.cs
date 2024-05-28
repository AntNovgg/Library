using CatalogService.Application.LinqSpecs.OrderSpecs;
using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using OrderingService.Application.LinqSpecs.OrderSpecs;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.LinqSpecs.Factory
{
    public class OrderSpecFactory : ISpecFactory<Order>
    {
        public Specification<Order> CreateSpecification(string? bookTittle, FullName authorFullName, DateTime plannedReturnDate, bool BookTittleSpec, bool BookAuthorSpec, bool PlannedReturnDateSpec)
        {
            Specification<Order> specification = new DefaultSpec();

            if (BookTittleSpec)
            {
                specification = new BookTittleSpec(bookTittle);
            }
            if (BookAuthorSpec)
            {
                specification = specification & new BookAuthorSpec(authorFullName);
            }
            if (PlannedReturnDateSpec)
            {
                specification = specification & new PlannedReturnDateSpec(plannedReturnDate);
            }
            return specification;
        }
    }
}
