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
        //// DDD Patterns comment
        //// Using a private collection field, better for DDD Aggregate's encapsulation
        //// so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        //// but only through the method OrderAggregateRoot.AddOrderItem() which includes behavior.
        //private readonly List<int> _booksIds;
        //public IReadOnlyCollection<int> BooksIds => _booksIds.AsReadOnly();


        public int BookId { get; private set; }
        public int RenterId { get; private set; }
        public Renter Renter { get; }        
        public DateTimeOffset OrderDate { get; private set; }
        public DateTimeOffset ReturnDate { get; private set; }
        public string BookTitle { get; private set; }
        public string BookAuthor { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment {  get; private set; } 
        public bool IsReturned { get; private set; }

        public Order(int bookId,
            int renterId,
            DateTimeOffset orderDate,
            DateTimeOffset returnDate)
        {
            BookId = bookId;
            RenterId = renterId;
            OrderDate = orderDate;
            ReturnDate = returnDate;            
            OrderStatus = 0;
            IsReturned = false;
        }

        public Order()
        {
        }
    }
}
