using Library.Domain.Interfaces;
using Library.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string BuyerId { get; private set; }
        public string BuyerFullName { get; private set;}
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset ReturnDate { get; private set; } 
        public string BookTitle { get; private set; }
        public string BookAuthor { get; private set;}
        public string BookGenre { get; private set;}
        enum Status
        {
            Active,
            Return,
            Expired
        }

    }
}
