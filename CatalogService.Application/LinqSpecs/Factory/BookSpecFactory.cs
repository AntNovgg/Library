
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
    public class BookSpecFactory : ISpecFactory<Book>
    {
        public Specification<Book> CreateSpecification(GetBookListBySpecQuery request)
        {
            Specification<Book> specification = new DefaultSpec();

            if (request.AvailabilitySpec)
            {
                specification = new AvailabilitySpec(true);
            }
            if (request.TitleSpec)
            {
                specification = specification & new TittleSpec(request.Title);
            }
            if (request.AuthorSpec)
            {
                specification = specification & new AuthorSpec(request.Author);
            }
            if (request.GenreSpec)
            {
                specification = specification & new GenreSpec(request.Genre);
            }
            return specification;
        }
    }
}
