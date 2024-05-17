using AutoMapper;
using CatalogService.Application.Commands.AddBook;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates;
using System.ComponentModel.DataAnnotations;

namespace CatalogService.WebApi.Models
{
    public class AddBookModel : IMapWith<AddBookCommand>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public Genre BookGenre { get; set; }
        [Required]
        public Condition BookCondition { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddBookModel, AddBookCommand>()
                .ForMember(bookCommand => bookCommand.Title,
                    opt => opt.MapFrom(bookModel => bookModel.Title))
                .ForMember(bookCommand => bookCommand.Author,
                    opt => opt.MapFrom(bookModel => bookModel.Author))
                .ForMember(bookCommand => bookCommand.BookGenre,
                    opt => opt.MapFrom(bookModel => bookModel.BookGenre))
                .ForMember(bookCommand => bookCommand.BookCondition,
                    opt => opt.MapFrom(bookModel => bookModel.BookCondition))
                .ForMember(bookCommand => bookCommand.IsAvailable,
                    opt => opt.MapFrom(bookModel => bookModel.IsAvailable));
        }
    }
}
