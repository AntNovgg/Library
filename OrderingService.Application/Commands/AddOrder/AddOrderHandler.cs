using Contracts;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using OrderingService.Application.Common.Interfaces;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Commands.AddOrder
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddOrderHandler(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = new Order(request.BookId,
                request.RenterId,
                request.OrderDate,
                request.PlannedReturnDate,
                request.BookTittle,
                request.BookAuthor,
                request.Comment);

                _orderRepository.Add(order);
                await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                /*Резервируем книгу*/
                await _publishEndpoint.Publish(new BookReservedEvent(request.BookId, order.Id), cancellationToken);

                return order.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(AddOrderHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }
        }
    }
}
