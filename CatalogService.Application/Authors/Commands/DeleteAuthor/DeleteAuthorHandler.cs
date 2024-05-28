using AutoMapper.Configuration;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using CatalogService.Domain.Aggregates.BookAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _authorRepository.GetAsync(request.Id);
                _authorRepository.Delete(entity);
                await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(DeleteAuthorHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
