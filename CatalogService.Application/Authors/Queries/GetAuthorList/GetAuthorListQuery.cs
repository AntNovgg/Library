using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorListDto>
    {        
    }
}
