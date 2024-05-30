using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderListBySpec
{
    public class OrderListBySpecDto
    {
        public IEnumerable<OrderLookupBySpecDto> Orders { get; set; }
    }
}
