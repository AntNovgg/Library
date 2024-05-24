using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Specifications.BookSpecifications;
using CatalogService.Application.Specifications.BookSpecifications.Factory;
using CatalogService.Domain.Aggregates;
using MassTransit;
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
        private readonly ISpecificationFactory<Book> _specificationFactory;

        public GetBookListBySpecHandler(ICatalogServiceContext context, IMapper mapper, ISpecFilter<Book> betterFilter, ISpecificationFactory<Book> specificationFactory)
        {
            _context = context;
            _mapper = mapper;
            _betterFilter = betterFilter;
            _specificationFactory = specificationFactory;
        }

        public async Task<BookListBySpecDto> Handle(GetBookListBySpecQuery request, CancellationToken cancellationToken)
        {
                var books = await _context.Books.ToListAsync();
                var spec = _specificationFactory.CreateSpecification(request);
                var filteredBooks = _betterFilter.Filter(books, spec);
                return new BookListBySpecDto { Books = filteredBooks };
        }
    }
}
