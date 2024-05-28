using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookDetailsHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request,
           CancellationToken cancellationToken)
        {

            var entity = await _bookRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<BookDetailsDto>(entity);
        }
    }
}
