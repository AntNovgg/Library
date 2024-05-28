using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogService.Application.Books.Queries.GetBookDetails
{
    public class BookDetailsDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public Guid AuthorId { get; set; }
        public string BookGenre { get; set; }
        public bool IsAvailable { get; set; }
        public Condition BookCondition { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsDto>()
                .ForMember(bookVm => bookVm.Tittle,
                    opt => opt.MapFrom(book => book.Tittle))
                .ForMember(bookVm => bookVm.AuthorId,
                    opt => opt.MapFrom(book => book.AuthorId))
                .ForMember(bookVm => bookVm.BookGenre,
                    opt => opt.MapFrom(book => book.BookGenre))
                .ForMember(bookVm => bookVm.IsAvailable,
                    opt => opt.MapFrom(book => book.IsAvailable))
                .ForMember(bookVm => bookVm.BookCondition,
                    opt => opt.MapFrom(book => book.BookCondition));
        }

    }
}
