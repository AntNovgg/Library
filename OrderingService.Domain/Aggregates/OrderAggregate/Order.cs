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
        public DateTimeOffset OrderDate { get; private set; }
        public DateTimeOffset ReturnDate { get; private set; }
        public string BookTitle { get; private set; }
        public string BookAuthor { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment {  get; private set; } 
        public bool IsReturned { get; private set; }

        public Order(int renterId,
            DateTimeOffset orderDate,
            DateTimeOffset returnDate,
            string bookTitle,
            string bookAuthor,
            OrderStatus orderStatus,
            bool isReturned)
        {
            RenterId = renterId;
            OrderDate = orderDate;
            ReturnDate = returnDate;
            BookTitle = bookTitle;
            BookAuthor = bookAuthor;
            OrderStatus = orderStatus;
            IsReturned = isReturned;
        }
    }
}
