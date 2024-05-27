
using CatalogService.Domain.Aggregates;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs
{
    public static class BookSpecs
    {
        public static Specification<Book> ByTitle(string title)
        {
            return new TittleSpec(title);
        }
    }
}
