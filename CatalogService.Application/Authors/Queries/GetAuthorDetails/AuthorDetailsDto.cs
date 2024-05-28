using AutoMapper;
using CatalogService.Application.Authors.Queries.GetAuthorList;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogService.Application.Authors.Queries.GetAuthorDetails
{
    public class AuthorDetailsDto : IMapWith<Author>
    {
        public FullName AuthorFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailsDto>()
                .ForMember(authorDto => authorDto.AuthorFullName,
                    opt => opt.MapFrom(author => author.AuthorFullName));
        }
    }
}
