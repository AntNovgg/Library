using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using static CatalogService.Domain.Aggregates.BookAggregate.Book;


namespace CatalogService.Application.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest<Guid>
    {
        public string Tittle { get; private set; }
        public Guid AuthorId { get; private set; }
        public Genre BookGenre { get; private set; }
        public Condition BookCondition { get; private set; }
        public bool IsAvailable { get; private set; }
    }
}
