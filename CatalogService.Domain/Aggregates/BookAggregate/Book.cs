using CatalogService.Domain.Aggregates.AuthorAggregate;
using CatalogService.Domain.Seeds;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Aggregates.BookAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        public Book(string tittle,
            Guid authorId,
            Genre bookGenre,
            bool isAvailable,
            Condition bookCondition)
        {
            Tittle = tittle;
            AuthorId = authorId;
            BookGenre = bookGenre;
            IsAvailable = isAvailable;
            BookCondition = bookCondition;
        }


        public string Tittle { get; private set; }
        public Guid AuthorId { get; private set; }
        public Author Author { get; }
        public Genre BookGenre { get; private set; }
        public Condition BookCondition { get; private set; }
        public bool IsAvailable { get; private set; }

        public void BookUpdate(string tittle,
            Guid authorId,
            Genre bookGenre,
            bool isAvailable,
            Condition bookCondition)
        {
            Tittle = tittle;
            AuthorId = authorId;
            BookGenre = bookGenre;
            IsAvailable = isAvailable;
            BookCondition = bookCondition;
        }
        public void BookReserved()
        {
            IsAvailable = false;
        }



    }
}
