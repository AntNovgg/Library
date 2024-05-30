using Contracts;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using OrderingService.Application.Common.Exceptions;
using OrderingService.Application.Orders.Commands.AddOrder;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Commands.CloseOrder
{
    public class CloseOrderHandler : IRequestHandler<CloseOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public CloseOrderHandler(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(CloseOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _orderRepository.GetAsync(request.Id);
                entity.CloseOrder(request.OrderStatus, request.Comment);
                await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);                
                await _publishEndpoint.Publish(new OrderClosedEvent(entity.BookId, (int)request.BookCondition), cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(CloseOrderHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }
    }
}
