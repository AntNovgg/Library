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
        public DateTimeOffset PlannedDate1 { get; set; }
        public DateTimeOffset PlannedDate2 { get; set; }

        public PlannedReturnDateSpec(DateTimeOffset plannedDate1, DateTimeOffset plannedDate2)
        {
            PlannedDate1 = plannedDate1;
            PlannedDate2 = plannedDate2;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => PlannedDate1 <= order.PlannedReturnDate.Date && order.PlannedReturnDate.Date <= PlannedDate2;
        }
    }
}
