using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Queries.GetAuthorList
{
    public class AuthorListDto
    {
        public IEnumerable<AuthorLookupDto> Authors { get; set; }
    }
}
