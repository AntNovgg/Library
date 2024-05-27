using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using static CatalogService.Domain.Aggregates.BookAggregate.Book;


namespace CatalogService.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }

    }
}
