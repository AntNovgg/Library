using AutoMapper;
using CatalogService.Application.LinqSpecs.Factory;
using CatalogService.Domain.Aggregates.BookAggregate;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Queries.GetBookListBySpec
{
    public class GetBookListBySpecHandler : IRequestHandler<GetBookListBySpecQuery, BookListBySpecDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ISpecFactory<Book> _specFactory;

        public GetBookListBySpecHandler(IBookRepository bookRepository, IMapper mapper, ISpecFactory<Book> specFactory)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _specFactory = specFactory;
        }

        public async Task<BookListBySpecDto> Handle(GetBookListBySpecQuery request, CancellationToken cancellationToken)
        {
            var spec = _specFactory.CreateSpecification(request.Title,
            request.AuthorId,
            request.Genre,
            request.TitleSpec,
            request.AuthorSpec,
            request.GenreSpec,
            request.AvailabilitySpec);

            var books = await _bookRepository.ListAll(spec);
            var booksDto = _mapper.Map<IEnumerable<BookLookupBySpecDto>>(books);            
            return new BookListBySpecDto { Books = booksDto };
        }
    }
}
