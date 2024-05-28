
using LinqSpecs;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.LinqSpecs.Factory
{
    public interface ISpecFactory<T>
    {
        Specification<T> CreateSpecification(string? bookTittle,
            FullName authorFullName,
            DateTime plannedReturnDate,
            bool BookTittleSpec,
            bool BookAuthorSpec,
            bool PlannedReturnDateSpec);
    }
}
