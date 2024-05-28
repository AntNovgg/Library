using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Queries.GetBookListBySpec
{
    public class GetBookListBySpecQuery : IRequest<BookListBySpecDto>
    {
        public string? Title;
        public Guid AuthorId;
        public Genre Genre;
        public bool TitleSpec;
        public bool AuthorSpec;
        public bool GenreSpec;
        public bool AvailabilitySpec;

        public GetBookListBySpecQuery(string? title,
            Guid authorId,
            Genre genre,
            bool titleSpec,
            bool authorSpec,
            bool genreSpec,
            bool availabilitySpec)
        {
            Title = title;
            AuthorId = authorId;
            Genre = genre;
            TitleSpec = titleSpec;
            AuthorSpec = authorSpec;
            GenreSpec = genreSpec;
            AvailabilitySpec = availabilitySpec;

        }
    }
}
