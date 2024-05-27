using CatalogService.Domain.Seeds;
using LinqSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Aggregates
{
    public class Book : Entity, IAggregateRoot
    {
        public Book(string title,
            string author,
            Genre bookGenre,
            bool isAvailable,
            Condition bookCondition)
        {            
            Title = title;
            Author = author;
            BookGenre = bookGenre;
            IsAvailable = isAvailable;
            BookCondition = bookCondition;
        }

        
        public string Title { get; private set; }
        public string Author { get; private set; }      
        public Genre BookGenre { get; private set; }
        public Condition BookCondition { get; private set; }
        public bool IsAvailable { get; private set; }

        public void BookUpdate(string title,
            string author,
            Genre bookGenre,
            bool isAvailable,
            Condition bookCondition)
        {
            Title = title;
            Author = author;
            BookGenre = bookGenre;
            IsAvailable = isAvailable;
            BookCondition = bookCondition;
        }
        public void BookReserved()
        {
            IsAvailable = false;
        }
        public static readonly Specification<Book> IsAvailableSpecQ =
            new AdHocSpecification<Book>(x=> x.IsAvailable);
        

    }
}
