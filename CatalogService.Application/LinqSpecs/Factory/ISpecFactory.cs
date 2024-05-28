using CatalogService.Domain.Aggregates.BookAggregate;
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
        Specification<T> CreateSpecification(string? tittle,
            Guid authorId,
            Genre genre,
            bool titleSpec,
            bool authorSpec,
            bool genreSpec,
            bool availabilitySpec);
    }
}
