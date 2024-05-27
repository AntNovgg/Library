using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CatalogService.Domain.Aggregates.BookAggregate.Book;

namespace CatalogService.Application.Queries.GetBookDetails
{
    public class BookDetailsDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Author { get; set; }
        public string BookGenre { get; set; }
        public bool IsAvailable { get; set; }
        public Condition BookCondition { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsDto>()
                .ForMember(bookVm => bookVm.Tittle,
                    opt => opt.MapFrom(book => book.Tittle))
                .ForMember(bookVm => bookVm.Author,
                    opt => opt.MapFrom(book => book.Author))
                .ForMember(bookVm => bookVm.BookGenre,
                    opt => opt.MapFrom(book => book.BookGenre))
                .ForMember(bookVm => bookVm.IsAvailable,
                    opt => opt.MapFrom(book => book.IsAvailable))
                .ForMember(bookVm => bookVm.BookCondition,
                    opt => opt.MapFrom(book => book.BookCondition));
        }

    }
}
