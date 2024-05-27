using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.LinqSpecs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Queries.GetBookList
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, BookListDto>
    {
        private readonly ICatalogServiceContext _context;
        private readonly IMapper _mapper;

        public GetBookListHandler(ICatalogServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookListDto> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await _context.Books.Where(p => p.IsAvailable == true)
               .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new BookListDto { Books = booksQuery };
        }
    }
}
