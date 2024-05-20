using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Domain.Aggregates.RenterAggregate
{
    public class Renter : Entity, IAggregateRoot
    {
        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggregateRoot.AddOrderItem() which includes behavior.
        private readonly List<int> _booksIds;
        public IReadOnlyCollection<int> BooksIds => _booksIds.AsReadOnly();
       
        // FullName is a Value Object pattern 
        [Required]
        public FullName RenterFullName { get; private set; }
        // Address is a Value Object pattern 
        [Required]
        public Address RenterAddress { get; private set; }
        public string Telephone { get; private set; }
        protected Renter()
        {
            _booksIds = new List<int>();            
        }
        public Renter(
            FullName renterFullName,
            Address renterAddress,
            string telephone) :this()
        {            
            RenterFullName = renterFullName;
            RenterAddress = renterAddress;
            Telephone = telephone;
        }
    }

}
