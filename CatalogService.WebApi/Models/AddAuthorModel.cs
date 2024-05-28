using AutoMapper;
using CatalogService.Application.Authors.Commands.AddAuthor;
using CatalogService.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.WebApi.Models
{
    public class AddAuthorModel : IMapWith<AddAuthorCommand>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddAuthorModel, AddAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                    opt => opt.MapFrom(authorModel => authorModel.Name))
                .ForMember(authorCommand => authorCommand.LastName,
                    opt => opt.MapFrom(authorModel => authorModel.LastName))
                .ForMember(authorCommand => authorCommand.MiddleName,
                    opt => opt.MapFrom(authorModel => authorModel.MiddleName));
        }
    }
}
