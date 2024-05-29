using CatalogService.Application.LinqSpecs.OrderSpecs;
using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using OrderingService.Application.LinqSpecs.OrderSpecs;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.LinqSpecs.Factory
{
    public class OrderSpecFactory : ISpecFactory<Order>
    {
        public Specification<Order> CreateSpecification(string? bookTittle,
            FullName authorFullName,
            DateTimeOffset plannedDate1,
            DateTimeOffset plannedDate2,
            DateTimeOffset orderDate1,
            DateTimeOffset orderDate2,
            bool bookTittleSpec,
            bool bookAuthorSpec,
            bool plannedReturnDateSpec,
            bool orderDateSpec)
        {
            Specification<Order> specification = new DefaultSpec();

            if (bookTittleSpec)
            {
                specification = new BookTittleSpec(bookTittle);
            }
            if (bookAuthorSpec)
            {
                specification = specification & new BookAuthorSpec(authorFullName);
            }
            if (plannedReturnDateSpec)
            {
                specification = specification & new PlannedReturnDateSpec(plannedDate1, plannedDate2);
            }
            if (orderDateSpec)
            {
                specification = specification & new OrderDateSpec(orderDate1, orderDate2);
            }
            return specification;
        }       
    }
}
