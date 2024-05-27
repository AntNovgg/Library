using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Domain.Aggregates.RenterAggregate
{
    public interface IRenterRepository : IRepository<Renter>
    {
        Renter Add(Renter renter);

        void Update(Renter renter);

        Task<Renter> GetAsync(int renterId);
    }
}
