using AutoMapper;
using CatalogService.Application.Books.Commands.UpdateBook;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.BookAggregate;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.WebApi.Models
{
    public class UpdateBookModel : IMapWith<UpdateBookCommand>
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }        
        public Guid AuthorId { get; set; }        
        public Genre BookGenre { get; set; }       
        public Condition BookCondition { get; set; }        
        public bool IsAvailable { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookModel, UpdateBookCommand>()
                .ForMember(bookCommand => bookCommand.Id,
                    opt => opt.MapFrom(bookModel => bookModel.Id))
                .ForMember(bookCommand => bookCommand.Tittle,
                    opt => opt.MapFrom(bookModel => bookModel.Tittle))
                .ForMember(bookCommand => bookCommand.AuthorId,
                    opt => opt.MapFrom(bookModel => bookModel.AuthorId))
                .ForMember(bookCommand => bookCommand.BookGenre,
                    opt => opt.MapFrom(bookModel => bookModel.BookGenre))
                .ForMember(bookCommand => bookCommand.BookCondition,
                    opt => opt.MapFrom(bookModel => bookModel.BookCondition))
                .ForMember(bookCommand => bookCommand.IsAvailable,
                    opt => opt.MapFrom(bookModel => bookModel.IsAvailable));
        }
    }
}
