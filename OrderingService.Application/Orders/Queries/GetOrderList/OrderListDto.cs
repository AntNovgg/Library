using OrderingService.Application.Orders.Queries.GetOrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderList
{
    public class OrderListDto
    {
        public IEnumerable<OrderLookupDto> Orders { get; set; }
    }
}
