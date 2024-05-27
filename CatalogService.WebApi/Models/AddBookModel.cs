using AutoMapper;
using CatalogService.Application.Commands.AddBook;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates.BookAggregate;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.WebApi.Models
{
    public class AddBookModel : IMapWith<AddBookCommand>
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public Genre BookGenre { get; set; }
        [Required]
        public Condition BookCondition { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddBookModel, AddBookCommand>()
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
