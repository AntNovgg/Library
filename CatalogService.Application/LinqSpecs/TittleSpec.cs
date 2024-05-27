using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs
{
    public class TittleSpec : Specification<Book>
    {
        public string Tittle { get; set; }

        public TittleSpec(string tittle)
        {
            Tittle = tittle;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return t => t.Tittle == Tittle;
        }
    }
}
