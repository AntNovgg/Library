using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQuery : IRequest<AuthorDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
