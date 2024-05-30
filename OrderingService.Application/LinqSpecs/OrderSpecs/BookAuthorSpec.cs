using CatalogService.Domain.Aggregates.BookAggregate;
using LinqSpecs;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.LinqSpecs.OrderSpecs
{
    public class BookAuthorSpec : Specification<Order>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

        public BookAuthorSpec(string name, string lastName, string middleName)
        {
            Name = name;
            LastName = lastName;
            MiddleName = middleName;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return t => t.AuthorFullName.Name == Name && t.AuthorFullName.LastName == LastName && t.AuthorFullName.MiddleName == MiddleName;
        }
    }
}
