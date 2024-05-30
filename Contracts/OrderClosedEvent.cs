using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingService.Domain.Aggregates.OrderAggregate;

namespace Contracts
{
    public record OrderClosedEvent(Guid bookId, int BookCondition);
    
}
