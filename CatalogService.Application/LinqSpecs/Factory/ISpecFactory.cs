using CatalogService.Application.Queries.GetBookListBySpec;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs.Factory
{
    public interface ISpecFactory<T>
    {
        Specification<T> CreateSpecification(GetBookListBySpecQuery request);
    }
}
