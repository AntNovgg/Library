using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;



namespace CatalogService.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public Guid Id { get; private set; }
        public FullName AuthorFullName { get; private set; }
    }
}
