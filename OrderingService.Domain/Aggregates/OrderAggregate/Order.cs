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
        public DateTimeOffset PlannedReturnDate { get; private set; }
        public DateTimeOffset ActualReturnDate { get; private set; }
        public string BookTitle { get; private set; }
        public string BookAuthor { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment {  get; private set; }         

        public Order(int bookId,
            int renterId,
            DateTimeOffset orderDate,
            DateTimeOffset plannedReturnDate,           
            string bookTitle,
            string bookAuthor,
            string comment)
        {
            BookId = bookId;
            RenterId = renterId;
            OrderDate = orderDate;
            PlannedReturnDate = plannedReturnDate;   
            BookTitle = bookTitle;
            BookAuthor = bookAuthor;
            OrderStatus = 0;
            Comment = comment;           
        }

        public Order()
        {
        }
    }
}
