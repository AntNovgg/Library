using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Specifications.BookSpecifications
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T p);

        public static Specification<T> operator &(
          Specification<T> first, Specification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }

    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly Specification<T>[] items;

        public CompositeSpecification(params Specification<T>[] items)
        {
            this.items = items;
        }
    }

    // combinator
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params Specification<T>[] items) : base(items)
        {
        }

        public override bool IsSatisfied(T t)
        {
            // Any -> OrSpecification
            return items.All(i => i.IsSatisfied(t));
        }
    }
}
