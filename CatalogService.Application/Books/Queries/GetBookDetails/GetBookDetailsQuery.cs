using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<BookDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
