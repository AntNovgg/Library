using Library.Domain.Interfaces;
using Library.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities.RenterAggregate
{
    public class Renter : Entity, IAggregateRoot
    {     
        public Guid RenterId { get; private set; }
        public FullName RenterFullName { get; private set; }
        public Address RenterAddress { get; private set; }
        public string Telephone { get; private set; }
        public Renter(Guid renterId,
            FullName renterFullName,
            Address renterAddress,
            string telephone)
        {
            RenterId = renterId;
            RenterFullName = renterFullName;
            RenterAddress = renterAddress;
            Telephone = telephone;
        }
    }
}
