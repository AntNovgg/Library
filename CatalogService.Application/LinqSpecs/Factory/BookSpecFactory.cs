
using CatalogService.Application.Queries.GetBookListBySpec;
using CatalogService.Domain.Aggregates.BookAggregate;
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
        public Specification<Book> CreateSpecification(string? tittle,
            Guid authorId,
            Genre genre,
            bool tittleSpec,
            bool authorSpec,
            bool genreSpec,
            bool availabilitySpec)
        {
            Specification<Book> specification = new DefaultSpec();

            if (availabilitySpec)
            {
                specification = new AvailabilitySpec(true);
            }
            if (tittleSpec)
            {
                specification = specification & new TittleSpec(tittle);
            }
            if (authorSpec)
            {
                specification = specification & new AuthorSpec(authorId);
            }
            if (genreSpec)
            {
                specification = specification & new GenreSpec(genre);
            }
            return specification;
        }
    }
}
