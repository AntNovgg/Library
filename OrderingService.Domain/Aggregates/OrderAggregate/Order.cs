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


        public Guid BookId { get; private set; }
        public Guid RenterId { get; private set; }
        public Renter Renter { get; }
        public DateTimeOffset OrderDate { get; private set; }
        public DateTimeOffset PlannedReturnDate { get; private set; }
        public DateTimeOffset ActualReturnDate { get; private set; }
        public string BookTittle { get; private set; }
        public FullName AuthorFullName { get; set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment {  get; private set; }         

        public Order(Guid bookId,
            Guid renterId,
            DateTimeOffset orderDate,
            DateTimeOffset plannedReturnDate,           
            string bookTittle,
            FullName authorFullName,
            string comment)
        {
            BookId = bookId;
            RenterId = renterId;
            OrderDate = orderDate;
            PlannedReturnDate = plannedReturnDate;   
            BookTittle = bookTittle;
            AuthorFullName = authorFullName;
            OrderStatus = 0;
            Comment = comment;           
        }
        public Order(Guid bookId,
            Guid renterId,
            DateTimeOffset orderDate,
            DateTimeOffset plannedReturnDate,
            string bookTittle,            
            string comment)
        {
            BookId = bookId;
            RenterId = renterId;
            OrderDate = orderDate;
            PlannedReturnDate = plannedReturnDate;
            BookTittle = bookTittle;            
            OrderStatus = 0;
            Comment = comment;
        }
        public Order()
        {
        }
        public void CloseOrder(OrderStatus orderStatus, string comment)
        { 
            OrderStatus = orderStatus;
            Comment = comment;
        }
    }
}
