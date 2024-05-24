using CatalogService.Application.Queries.GetBookListBySpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications.Factory
{
    public interface ISpecificationFactory<T>
    {
        Specification<T> CreateSpecification(GetBookListBySpecQuery request);
    }
}
