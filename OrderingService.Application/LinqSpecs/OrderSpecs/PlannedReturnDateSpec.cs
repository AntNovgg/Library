using OrderingService.Domain.Aggregates.OrderAggregate;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.LinqSpecs.OrderSpecs
{
    public class PlannedReturnDateSpec : Specification<Order>
    {
        public DateTimeOffset PlannedReturnDate { get; set; }

        public PlannedReturnDateSpec(DateTimeOffset plannedReturnDate)
        {
            PlannedReturnDate = plannedReturnDate;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.PlannedReturnDate < PlannedReturnDate;
        }
    }
}
