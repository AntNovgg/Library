using AutoMapper;
using OrderingService.Application.Common.Mappings;
using OrderingService.Application.Orders.Commands.CloseOrder;
using OrderingService.Domain.Aggregates.OrderAggregate;

namespace OrderingService.WebApi.Models
{
    public class CloseOrderModel : IMapWith<CloseOrderCommand>
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Comment { get; set; }
        public BookCondition BookCondition { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CloseOrderModel, CloseOrderCommand>()
                .ForMember(orderCommand => orderCommand.Id,
                    opt => opt.MapFrom(orderModel => orderModel.Id))
                .ForMember(orderCommand => orderCommand.OrderStatus,
                    opt => opt.MapFrom(orderModel => orderModel.OrderStatus))
                .ForMember(orderCommand => orderCommand.Comment,
                    opt => opt.MapFrom(orderModel => orderModel.Comment))
                .ForMember(orderCommand => orderCommand.BookCondition,
                    opt => opt.MapFrom(orderModel => orderModel.BookCondition));
        }
    }
}
