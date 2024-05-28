using CatalogService.Domain.Aggregates.AuthorAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _authorRepository.GetAsync(request.Id);
                entity.AuthorUpdate(request.AuthorFullName);
                _authorRepository.Update(entity);
                await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(UpdateAuthorHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
