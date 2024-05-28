using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.LinqSpecs;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace CatalogService.Application.Books.Queries.GetBookList
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, BookListDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookListDto> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.ListAllAsync();
            var booksDto = _mapper.Map<IEnumerable<BookLookupDto>>(books);

            return new BookListDto { Books = booksDto };
        }
    }
}
