using AutoMapper;
using CatalogService.Application.Authors.Commands.UpdateAuthor;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.WebApi.Models
{
    public class UpdateAuthorModel : IMapWith<UpdateAuthorCommand>
    {
        public Guid Id { get; set; }
        public FullName AuthorFullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorModel, UpdateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Id,
                    opt => opt.MapFrom(authorModel => authorModel.Id))
                .ForMember(authorCommand => authorCommand.AuthorFullName,
                    opt => opt.MapFrom(authorModel => authorModel.AuthorFullName));
        }
    }
}
