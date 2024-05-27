using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.BookReservedFailed
{
    public class BookReservedFailedCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
