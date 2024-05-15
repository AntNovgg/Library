using Library.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities.OrderAggregate
{
    public class OrderBook : Entity
    {
        public Guid? BookId { get; private set; }
    }
}
