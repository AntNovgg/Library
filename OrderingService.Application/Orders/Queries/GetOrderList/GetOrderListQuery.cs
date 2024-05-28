using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListDto>
    {
    }
}
