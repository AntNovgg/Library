using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Books.Queries.GetBookListBySpec
{
    public class BookListBySpecDto
    {
        public IEnumerable<BookLookupBySpecDto> Books { get; set; }
    }
}
