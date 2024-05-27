using CatalogService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Aggregates.AuthorAggregate
{
    public class Author : Entity, IAggregateRoot
    {
        [Required]
        public FullName AuthorFullName { get; private set; }
    }
}
