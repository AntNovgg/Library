using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Aggregates.AuthorAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.AddAuthor
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand, Guid>
    {
        private readonly ICatalogServiceContext _context;
        public AddAuthorHandler(ICatalogServiceContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fullname = new FullName(request.Name,
                    request.LastName,
                    request.MiddleName);

                Author author = new Author(fullname);
                _renterRepository.Add(renter);
                await _renterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return renter.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(AddAuthorHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
