using AutoMapper;
using OrderingService.Application.Common.Mappings;
using OrderingService.Application.Orders.Queries.GetOrderDetails;
using OrderingService.Application.Orders.Queries.GetOrderList;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderListBySpec
{
    public class OrderLookupBySpecDto : IMapWith<Order>
    {
        public DateTimeOffset OrderDate { get; private set; }
        public DateTimeOffset PlannedReturnDate { get; private set; }
        public DateTimeOffset ActualReturnDate { get; private set; }
        public string BookTittle { get; private set; }
        public FullName AuthorFullName { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public string Comment { get; private set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupBySpecDto>()
                .ForMember(bookVm => bookVm.Comment,
                    opt => opt.MapFrom(book => book.Comment))
                .ForMember(bookVm => bookVm.OrderDate,
                    opt => opt.MapFrom(book => book.OrderDate))
                .ForMember(bookVm => bookVm.PlannedReturnDate,
                    opt => opt.MapFrom(book => book.PlannedReturnDate))
                .ForMember(bookVm => bookVm.ActualReturnDate,
                    opt => opt.MapFrom(book => book.ActualReturnDate))
                .ForMember(bookVm => bookVm.BookTittle,
                    opt => opt.MapFrom(book => book.BookTittle))
                .ForMember(bookVm => bookVm.AuthorFullName,
                    opt => opt.MapFrom(book => book.AuthorFullName))
                .ForMember(bookVm => bookVm.OrderStatus,
                    opt => opt.MapFrom(book => book.OrderStatus));
        }
    }

}
