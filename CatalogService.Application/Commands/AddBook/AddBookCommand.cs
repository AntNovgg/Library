using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using static CatalogService.Domain.Aggregates.Book;


namespace CatalogService.Application.Commands.AddBook
{
    public class UpdateBookCommand : IRequest<Guid>
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public Condition BookCondition { get; private set; }
    }
}
