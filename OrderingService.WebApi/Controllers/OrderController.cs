using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Application.Orders.Commands.AddOrder;
using OrderingService.Application.Orders.Queries.GetOrderDetails;
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
        /// <summary>
        /// Gets the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /order/D4837E56-F064-450A-84E6-983352B2E9C1
        /// </remarks>
        /// <param name="id">Order id (guid)</param>
        /// <returns>Returns OrderDetailsDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDetailsDto>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {                
                Id = id
            };
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
