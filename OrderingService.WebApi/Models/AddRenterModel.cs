using AutoMapper;
using OrderingService.Application.Common.Mappings;
using OrderingService.Application.Renters.Commands.AddRenter;

namespace OrderingService.WebApi.Models
{
    public class AddRenterModel : IMapWith<AddRenterCommand>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddRenterModel, AddRenterCommand>()
                .ForMember(orderCommand => orderCommand.Name,
                    opt => opt.MapFrom(orderModel => orderModel.Name))
                .ForMember(orderCommand => orderCommand.LastName,
                    opt => opt.MapFrom(orderModel => orderModel.LastName))
                .ForMember(orderCommand => orderCommand.MiddleName,
                    opt => opt.MapFrom(orderModel => orderModel.MiddleName))
                .ForMember(orderCommand => orderCommand.Street,
                    opt => opt.MapFrom(orderModel => orderModel.Street))
                .ForMember(orderCommand => orderCommand.City,
                    opt => opt.MapFrom(orderModel => orderModel.City))
                .ForMember(orderCommand => orderCommand.State,
                    opt => opt.MapFrom(orderModel => orderModel.State))
                .ForMember(orderCommand => orderCommand.Country,
                    opt => opt.MapFrom(orderModel => orderModel.Country))
                .ForMember(orderCommand => orderCommand.ZipCode,
                    opt => opt.MapFrom(orderModel => orderModel.ZipCode))
                .ForMember(orderCommand => orderCommand.Telephone,
                    opt => opt.MapFrom(orderModel => orderModel.Telephone));
        }
    }    
    
}
