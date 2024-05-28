using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using OrderingService.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs.OrderSpecs
{
    public class BookTittleSpec : Specification<Order>
    {
        public string BookTittle { get; set; }

        public BookTittleSpec(string bookTittle)
        {
            BookTittle = bookTittle;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.BookTittle == BookTittle;
        }
    }
}
