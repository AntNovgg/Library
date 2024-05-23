using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Specifications.BookSpecifications;
using CatalogService.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Queries.GetBookListBySpec
{
    public class GetBookListBySpecHandler : IRequestHandler<GetBookListBySpecQuery, BookListDto>
    {
        private readonly ICatalogServiceContext _context;
        private readonly IMapper _mapper;

        public GetBookListBySpecHandler(ICatalogServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookListDto> Handle(GetBookListBySpecQuery request, CancellationToken cancellationToken)
        {
            //var booksQuery = await _context.Books.Where(p => p.IsAvailable == true)
            //   .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
            //   .ToListAsync(cancellationToken);

            //return new BookListDto { Books = booksQuery };
            if (request.Title != null && request.Author == null && !Enum.IsDefined(typeof(Genre), request.Genre))
            {
                var booksQuery = await _context.Books.Where(p => p.Title == request.Title);
                var titlespec = new TitleSpecification(request.Title);
                var bf = new BetterFilter();
                bf.Filter()

            }
        }
    }
}
