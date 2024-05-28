using AutoMapper;
using CatalogService.Application.Authors.Queries.GetAuthorDetails;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsHandler : IRequestHandler<GetAuthorDetailsQuery, AuthorDetailsDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorDetailsHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDetailsDto> Handle(GetAuthorDetailsQuery request,
           CancellationToken cancellationToken)
        {

            var entity = await _authorRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            return _mapper.Map<AuthorDetailsDto>(entity);
        }
    }
}
