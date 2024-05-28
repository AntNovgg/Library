using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Authors.Queries.GetAuthorList;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.LinqSpecs;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListHandler : IRequestHandler<GetAuthorListQuery, AuthorListDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorListHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorListDto> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.ListAllAsync();
            var authorsDto = _mapper.Map<IEnumerable<AuthorLookupDto>>(authors);

            return new AuthorListDto { Authors = authorsDto };
        }
    }
}
