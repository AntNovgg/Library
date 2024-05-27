using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Application.Commands.AddOrder;
using OrderingService.Application.Renters.Commands.AddRenter;
using OrderingService.WebApi.Models;

namespace OrderingService.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RenterController : BaseController
    {
        private readonly IMapper _mapper;

        public RenterController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Creates the renter
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /renter
        /// {
        ///     name: "rentered name",
        ///     lastname: "rentered lastname",
        ///     middlename: "rentered middlename",
        ///     street: "street",
        ///     city: "city",
        ///     state: "state",
        ///     country: "country",
        ///     zipcode: "zipcode",
        ///     telephone: "telephone"
        ///    
        /// }
        /// </remarks>
        /// <param name="addRenterModel">AddRenterModel object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> AddRenter([FromBody] AddRenterModel addRenterModel)
        {
            var command = _mapper.Map<AddRenterCommand>(addRenterModel);

            var renterId = await Mediator.Send(command);
            return Ok(renterId);
        }
    }
}
