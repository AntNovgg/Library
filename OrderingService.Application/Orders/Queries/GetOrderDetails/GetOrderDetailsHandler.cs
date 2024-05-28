using AutoMapper;
using MediatR;
using OrderingService.Application.Common.Exceptions;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request,
           CancellationToken cancellationToken)
        {

            var entity = await _orderRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDetailsDto>(entity);
        }
    }
}
