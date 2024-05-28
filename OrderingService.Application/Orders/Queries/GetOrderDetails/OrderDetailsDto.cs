using AutoMapper;
using CatalogService.Domain.Aggregates.BookAggregate;
using OrderingService.Application.Common.Mappings;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsDto : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public Guid RenterId { get; set; }        
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset PlannedReturnDate { get; set; }
        public DateTimeOffset ActualReturnDate { get; set; }
        public string BookTittle { get; set; }
        public FullName AuthorFullName { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsDto>()
                .ForMember(bookVm => bookVm.RenterId,
                    opt => opt.MapFrom(book => book.RenterId))
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
