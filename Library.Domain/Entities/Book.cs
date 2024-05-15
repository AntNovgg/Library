using Library.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book : Entity
    {
        public Guid? BookId { get; private set; }
        /// <summary>
        /// ID книги
        /// </summary>
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public bool IsAvailable { get; private set; }

        public Book(Guid? bookId,
            string title,
            string author,
            string genre)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Genre = genre;
            IsAvailable = true;
        }
    }
}
