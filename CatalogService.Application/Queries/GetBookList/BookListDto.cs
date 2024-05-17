using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Queries.GetBookList
{
    public class BookListDto
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
