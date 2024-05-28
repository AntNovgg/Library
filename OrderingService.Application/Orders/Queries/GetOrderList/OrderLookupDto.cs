using AutoMapper;
using OrderingService.Application.Common.Mappings;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
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
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(bookDto => bookDto.OrderDate,
                    opt => opt.MapFrom(book => book.OrderDate))
                .ForMember(bookDto => bookDto.PlannedReturnDate,
                    opt => opt.MapFrom(book => book.PlannedReturnDate))
                .ForMember(bookDto => bookDto.ActualReturnDate,
                    opt => opt.MapFrom(bookModel => bookModel.ActualReturnDate))
                .ForMember(bookDto => bookDto.BookTittle,
                    opt => opt.MapFrom(bookModel => bookModel.BookTittle))
                .ForMember(bookDto => bookDto.AuthorFullName,
                    opt => opt.MapFrom(bookModel => bookModel.AuthorFullName))
                .ForMember(bookDto => bookDto.OrderStatus,
                    opt => opt.MapFrom(bookModel => bookModel.OrderStatus))
                .ForMember(bookDto => bookDto.Comment,
                    opt => opt.MapFrom(bookModel => bookModel.Comment));
        }
    }

}
