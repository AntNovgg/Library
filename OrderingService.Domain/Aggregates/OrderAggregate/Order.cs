using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    
    {
        public int RenterId { get; private set; }
        public Renter Renter { get; }
        public OrderStatus OrderStatus { get; private set; }
        public DateTimeOffset OrderDate { get; private set; }
        public DateTimeOffset ReturnDate { get; private set; }
        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggregateRoot.AddOrderItem() which includes behavior.
        private readonly List<OrderBook> _orderBooks;

        public IReadOnlyCollection<OrderBook> OrderBooks => _orderBooks.AsReadOnly();
        protected Order()
        {
            _orderBooks = new List<OrderBook>();
            
        }

        public Order(DateTimeOffset returnDate, int renterId) : this()
        {
            RenterId = renterId;            
            OrderStatus = OrderStatus.Active;            
            ReturnDate = returnDate;
            OrderDate = DateTime.UtcNow;

        }
    }
}
