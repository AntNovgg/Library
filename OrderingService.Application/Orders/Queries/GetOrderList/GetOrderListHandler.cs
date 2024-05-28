using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace OrderingService.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, OrderListDto>
    {
        private readonly IOrderRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetOrderListHandler(IOrderRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<OrderListDto> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.ListAllAsync();
            var booksDto = _mapper.Map<IEnumerable<OrderLookupDto>>(books);

            return new OrderListDto { Orders = booksDto };
        }
    }
}
