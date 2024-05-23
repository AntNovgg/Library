using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Specifications.BookSpecifications;
using CatalogService.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Queries.GetBookListBySpec
{
    public class GetBookListBySpecHandler : IRequestHandler<GetBookListBySpecQuery, BookListBySpecDto>
    {
        private readonly ICatalogServiceContext _context;
        private readonly IMapper _mapper;
        private readonly ISpecFilter<Book> _betterFilter;

        public GetBookListBySpecHandler(ICatalogServiceContext context, IMapper mapper, ISpecFilter<Book> betterFilter)
        {
            _context = context;
            _mapper = mapper;
            _betterFilter = betterFilter;
        }

        public async Task<BookListBySpecDto> Handle(GetBookListBySpecQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.ToListAsync();
            
            if (request.TitleSpec)
            {
                var titleSpec = new TitleSpecification(request.Title);
                var filteredBooks = _betterFilter.Filterr(books, titleSpec);
                return new BookListBySpecDto { Books = filteredBooks };
            }
            else if (request.AuthorSpec)
            {
                var authorSpec = new AuthorSpecification(request.Author);
                var filteredBooks = _betterFilter.Filterr(books, authorSpec);
                return new BookListBySpecDto { Books = filteredBooks };
            }
            else if (request.GenreSpec)
            {
                var genreSpec = new GenreSpecification(request.Genre);
                var filteredBooks = _betterFilter.Filterr(books, genreSpec);
                return new BookListBySpecDto { Books = filteredBooks };
            }
            else if (request.TitleSpec & request.AuthorSpec)
            {
                var titleAuthorSpec = new AndSpecification<Book>(new TitleSpecification(request.Title)
                                 & new AuthorSpecification(request.Author));
                var filteredBooks = _betterFilter.Filterr(books, titleAuthorSpec);
                return new BookListBySpecDto { Books = filteredBooks };
            }
            var allbooks = await _context.Books
               .ProjectTo<BookLookupBySpecDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
            return new BookListBySpecDto { Books = allbooks };
        }
    }
}
