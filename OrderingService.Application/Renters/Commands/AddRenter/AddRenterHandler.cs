using MassTransit.Transports;
using MediatR;
using OrderingService.Application.Commands.AddOrder;
using OrderingService.Application.Common.Interfaces;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Renters.Commands.AddRenter
{
    public class AddRenterHandler : IRequestHandler<AddRenterCommand, Guid>
    {
        private readonly IRenterRepository _renterRepository;

        public AddRenterHandler(IRenterRepository renterRepository)
        {
            _renterRepository = renterRepository;
        }

        public async Task<Guid> Handle(AddRenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = new Address(request.Street,
                    request.City, request.State,
                    request.Country,
                    request.ZipCode);

                var fullname = new FullName(request.Name,
                    request.LastName,
                    request.MiddleName);

                Renter renter = new Renter(fullname, address, request.Telephone);
                _renterRepository.Add(renter);
                await _renterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

                return renter.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = $"{DateTime.Now} - произошла ошибка при выполнении метода {nameof(AddRenterHandler)} - {ex.Message}";
                throw new Exception(errorMessage);
            }


        }
    }
}
