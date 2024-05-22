using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.ReserveBook
{
    public class ReserveBookCommand : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookGenre { get; set; }
        public bool IsAvailable { get; set; }
        public Condition BookCondition { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, ReserveBookCommand>()
                .ForMember(bookVm => bookVm.Title,
                    opt => opt.MapFrom(book => book.Title))
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
