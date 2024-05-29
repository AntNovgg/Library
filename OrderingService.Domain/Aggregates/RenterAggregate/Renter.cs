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
        // FullName is a Value Object pattern 
        [Required]        
        public FullName RenterFullName { get; private set; }
        // Address is a Value Object pattern 
        [Required]        
        public Address RenterAddress { get; private set; }
        public string Telephone { get; private set; }
        
        public Renter(FullName renterFullName,
            Address renterAddress,
            string telephone) : this(telephone)
        {
            RenterFullName = renterFullName;
            RenterAddress = renterAddress;
        }
        private Renter(string telephone) : base()
        {
            Telephone = telephone;
        }
    }

}
