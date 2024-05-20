using MediatR;
using OrderingService.Domain.Aggregates.RenterAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Commands.AddRenter
{
    public class AddRenterCommand : IRequest<Guid>
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }
        public string Telephone { get; private set; }
       
    }
}
