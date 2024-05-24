using CatalogService.Application.Queries.GetBookListBySpec;
using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications.Factory
{
    public class BookSpecificationFactory : ISpecificationFactory<Book>
    {
        public Specification<Book> CreateSpecification(GetBookListBySpecQuery request)
        {
            Specification<Book> specification = new DefaultSpecification();

            if (request.AvailabilitySpec)
            {
                specification = new AvailabilitySpecification(true);
            }
            if (request.TitleSpec)
            {
                specification = specification & new TitleSpecification(request.Title);
            }
            if (request.AuthorSpec)
            {
                specification = specification & new AuthorSpecification(request.Author);
            }
            if (request.GenreSpec)
            {
                specification = specification & new GenreSpecification(request.Genre);
            }
            return specification;
        }
    }
}
