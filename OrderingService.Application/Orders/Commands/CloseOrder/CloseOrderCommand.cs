using MediatR;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Commands.CloseOrder
{
    public class CloseOrderCommand : IRequest
    {
        public Guid Id { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment { get; private set; }
        public BookCondition BookCondition { get; private set; }

    }
}
