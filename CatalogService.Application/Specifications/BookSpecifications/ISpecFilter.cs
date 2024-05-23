using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items,
            Specification<T> spec);
    }
}
