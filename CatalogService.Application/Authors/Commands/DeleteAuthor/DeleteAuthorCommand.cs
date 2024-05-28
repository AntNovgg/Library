using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using static CatalogService.Domain.Aggregates.BookAggregate.Book;


namespace CatalogService.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid Id { get; set; }

    }
}
