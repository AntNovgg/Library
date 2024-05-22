using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        ///     title: "order title",
        ///     author: "order author",
        ///     genre: "order genre",
        ///     ordercondition: "order condition",
        ///     isavailable:  "order availability"
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
