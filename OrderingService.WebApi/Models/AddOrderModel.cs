using AutoMapper;
using OrderingService.Application.Commands.AddOrder;
using OrderingService.Application.Common.Mappings;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;

namespace OrderingService.WebApi.Models
{
    public class AddOrderModel : IMapWith<AddOrderCommand>
    {
        public Guid BookId { get; set; }
        public Guid RenterId { get; set; }        
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset PlannedReturnDate { get; set; }
        public DateTimeOffset ActualReturnDate { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Comment { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddOrderModel, AddOrderCommand>()
                .ForMember(orderCommand => orderCommand.BookId,
                    opt => opt.MapFrom(orderModel => orderModel.BookId))
                .ForMember(orderCommand => orderCommand.RenterId,
                    opt => opt.MapFrom(orderModel => orderModel.RenterId))
                .ForMember(orderCommand => orderCommand.OrderDate,
                    opt => opt.MapFrom(orderModel => orderModel.OrderDate))
                .ForMember(orderCommand => orderCommand.PlannedReturnDate,
                    opt => opt.MapFrom(orderModel => orderModel.PlannedReturnDate))
                .ForMember(orderCommand => orderCommand.ActualReturnDate,
                    opt => opt.MapFrom(orderModel => orderModel.ActualReturnDate))
                .ForMember(orderCommand => orderCommand.BookTitle,
                    opt => opt.MapFrom(orderModel => orderModel.BookTitle))
                .ForMember(orderCommand => orderCommand.BookAuthor,
                    opt => opt.MapFrom(orderModel => orderModel.BookAuthor))
                .ForMember(orderCommand => orderCommand.OrderStatus,
                    opt => opt.MapFrom(orderModel => orderModel.OrderStatus))
                .ForMember(orderCommand => orderCommand.Comment,
                    opt => opt.MapFrom(orderModel => orderModel.Comment));
        }
    }    
}
