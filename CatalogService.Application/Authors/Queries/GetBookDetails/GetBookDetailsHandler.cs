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

namespace CatalogService.Application.Queries.GetBookDetails
{
    public class GetBookDetailsHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
    {
        private readonly ICatalogServiceContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailsHandler(ICatalogServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request,
           CancellationToken cancellationToken)
        {
            
            var entity = await _context.Books
                .FirstOrDefaultAsync(book =>
                book.Id == request.Id, cancellationToken);           

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<BookDetailsDto>(entity);
        }
    }
}
