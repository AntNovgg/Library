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
    public class OrderStatusSpec : Specification<Order>
    {
        public OrderStatus OrderStatus { get; set; }

        public OrderStatusSpec(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.OrderStatus == OrderStatus;
        }
    }
}
