using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Specifications.BookSpecifications;
using CatalogService.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Queries.GetBookListBySpec
{
    public class GetBookListBySpecQuery : IRequest<BookListDto>
    {
        public string? Title;
        public string? Author;
        public Genre Genre;
        public bool 

        public GetBookListBySpecQuery(string? title,
            string? author,
            Genre genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }
    }    
}
