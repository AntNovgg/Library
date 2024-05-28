using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Commands.AddAuthor
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;

        public AddAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Guid> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fullname = new FullName(request.Name,
                    request.LastName,
                    request.MiddleName);

                CatalogService.Domain.Aggregates.AuthorAggregate.Author author = new Domain.Aggregates.AuthorAggregate.Author(fullname);
                _authorRepository.Add(author);
                await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return author.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(AddAuthorHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
