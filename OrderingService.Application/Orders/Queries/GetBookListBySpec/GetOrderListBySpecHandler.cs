using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderingService.Application.LinqSpecs.Factory;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderListBySpec
{
    public class GetOrderListBySpecHandler : IRequestHandler<GetOrderListBySpecQuery, OrderListBySpecDto>
    {
        private readonly IOrderRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ISpecFactory<Order> _specFactory;

        public GetOrderListBySpecHandler(IOrderRepository bookRepository, IMapper mapper, ISpecFactory<Order> specFactory)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _specFactory = specFactory;
        }

        public async Task<OrderListBySpecDto> Handle(GetOrderListBySpecQuery request, CancellationToken cancellationToken)
        {
            var spec = _specFactory.CreateSpecification(request.BookTittle,
            request.AuthorFullName,
            request.PlannedDate1,
            request.PlannedDate2,
            request.OrderDate1,
            request.OrderDate2,
            request.BookTittleSpec,
            request.BookAuthorSpec,
            request.PlannedReturnDateSpec,
            request.OrderDateSpec);

            var books = await _bookRepository.ListAll(spec);
            var booksDto = _mapper.Map<IEnumerable<OrderLookupBySpecDto>>(books);            
            return new OrderListBySpecDto { Orders = booksDto };
        }
    }
}
