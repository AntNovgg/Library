using OrderingService.Application.Common.Mappings;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Queries.GetOrderDetails
{
    public class OrderDetailsDto : IMapWith<Order>
    {
        public Guid Id { get; set; }

    }
}
