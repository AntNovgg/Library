
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
    public interface ISpecFactory<T>
    {
        Specification<T> CreateSpecification(string? bookTittle,
            string? name,
            string? lastName,
            string? middleName,
            DateTimeOffset plannedDate1,
            DateTimeOffset plannedDate2,
            DateTimeOffset orderDate1,
            DateTimeOffset orderDate2,
            OrderStatus orderStatus,
            bool bookTittleSpec,
            bool bookAuthorSpec,
            bool plannedReturnDateSpec,
            bool orderDateSpec,
            bool OrderStatusSpec);
    }
}
