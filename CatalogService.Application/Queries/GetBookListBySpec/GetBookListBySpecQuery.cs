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
    public class GetBookListBySpecQuery : IRequest<BookListBySpecDto>
    {
        public string? Title;
        public string? Author;
        public Genre Genre;
        public bool TitleSpec;
        public bool AuthorSpec;
        public bool GenreSpec;
        public bool AvailabilitySpec;

        public GetBookListBySpecQuery(string? title,
            string? author,
            Genre genre,
            bool titleSpec,
            bool authorSpec,
            bool genreSpec,
            bool availabilitySpec)
        {
            Title = title;
            Author = author;
            Genre = genre;
            TitleSpec = titleSpec;
            AuthorSpec = authorSpec;
            GenreSpec = genreSpec;
            AvailabilitySpec = availabilitySpec;
        }
    }    
}
