using MediatR;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<Guid>
    {
        public int RenterId { get; private set; }
        public Renter Renter { get; }
        public DateTimeOffset OrderDate { get; private set; }
        public DateTimeOffset ReturnDate { get; private set; }
        public string BookTitle { get; private set; }
        public string BookAuthor { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment { get; private set; }
        public bool IsReturned { get; private set; }
    }
}
