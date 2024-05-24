using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Application.Commands.AddOrder;
using OrderingService.WebApi.Models;

namespace OrderingService.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Creates the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /order
        /// {
        ///     bookId: "rentered book Id",
        ///     renterId: "renter Id",
        ///     orderdate: "order date",
        ///     plannedReturnDate: "planned book return date",
        ///     booktitle:  "rentered book title",
        ///     bookauthor: "rentered book author",
        ///     comment: "any order comments"
        /// }
        /// </remarks>
        /// <param name="addOrderModel">AddOrderModel object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> AddOrder([FromBody] AddOrderModel addOrderModel)
        {
            var command = _mapper.Map<AddOrderCommand>(addOrderModel);

            var orderId = await Mediator.Send(command);

            return Ok(orderId);
        }
    }
}
