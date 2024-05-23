using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Queries.GetBookListBySpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public interface ISpecFilter<T>
    {
        IList<BookLookupBySpecDto> Filterr(IEnumerable<T> items,
            Specification<T> spec);
    }

}
