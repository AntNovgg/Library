using CatalogService.Application.Queries.GetBookListBySpec;
using CatalogService.Domain.Aggregates;
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
        Specification<T> CreateSpecification(string? title,
            string? author,
            Genre genre,
            bool titleSpec,
            bool authorSpec,
            bool genreSpec,
            bool availabilitySpec);
    }
}
