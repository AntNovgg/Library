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
    public class OrderDateSpec : Specification<Order>
    {
        public DateTimeOffset OrderDate1 { get; set; }
        public DateTimeOffset OrderDate2 { get; set; }

        public OrderDateSpec(DateTimeOffset orderDate1, DateTimeOffset orderDate2)
        {
            OrderDate1 = orderDate1.Date;
            OrderDate2 = orderDate2.Date;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => OrderDate1 <= order.PlannedReturnDate.Date && order.PlannedReturnDate.Date <= OrderDate2;
        }
    }
}
