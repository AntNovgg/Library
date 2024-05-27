using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Queries.GetBookListBySpec
{
    public class BookLookupBySpecDto : IMapWith<Book>
    {
        
        public string Tittle { get; set; }
        public Guid AuthorId { get; set; }
        public Genre BookGenre { get; set; }
        public Condition BookCondition { get; set; }
        public bool IsAvailable { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupBySpecDto>()                
                .ForMember(bookDto => bookDto.Tittle,
                    opt => opt.MapFrom(book => book.Tittle))
                .ForMember(bookDto => bookDto.AuthorId,
                    opt => opt.MapFrom(book => book.AuthorId))
                .ForMember(bookCommand => bookCommand.BookGenre,
                    opt => opt.MapFrom(bookModel => bookModel.BookGenre))
                .ForMember(bookCommand => bookCommand.BookCondition,
                    opt => opt.MapFrom(bookModel => bookModel.BookCondition))
                .ForMember(bookCommand => bookCommand.IsAvailable,
                    opt => opt.MapFrom(bookModel => bookModel.IsAvailable));
        }
    }
    
}
