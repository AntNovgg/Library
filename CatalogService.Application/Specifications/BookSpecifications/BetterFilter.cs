using AutoMapper;
using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Queries.GetBookListBySpec;
using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public class BetterFilter : ISpecFilter<Book>
    {
        private readonly IMapper _mapper;

        public BetterFilter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IList<BookLookupBySpecDto> Filterr(IEnumerable<Book> items,
            Specification<Book> spec)
        {
            var filteredItems = items.Where(i => spec.IsSatisfied(i)).ToList();
            return _mapper.ProjectTo<BookLookupBySpecDto>(filteredItems.AsQueryable(), null, null).ToList();
        }
    }
}
