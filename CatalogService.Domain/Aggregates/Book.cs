using CatalogService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Aggregates
{
    public class Book : Entity
    {
        public Book(string title,
            string author,
            string genre,
            bool isAvailable,
            Condition bookCondition)
        {            
            Title = title;
            Author = author;
            Genre = genre;
            IsAvailable = isAvailable;
            BookCondition = bookCondition;
        }

        
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public bool IsAvailable { get; private set; }
        public Condition BookCondition { get; private set; }
        public enum Condition
        {
            Great,
            Good,
            Bad
        }

        
    }
}
