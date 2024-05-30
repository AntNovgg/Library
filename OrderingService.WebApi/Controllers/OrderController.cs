using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Application.Orders.Commands.AddOrder;
using OrderingService.Application.Orders.Commands.CloseOrder;
using OrderingService.Application.Orders.Queries.GetOrderDetails;
using OrderingService.Application.Orders.Queries.GetOrderList;
using OrderingService.Application.Orders.Queries.GetOrderListBySpec;
using OrderingService.Domain.Aggregates.OrderAggregate;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
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
        /// Gets the list of orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /order
        /// </remarks>
        /// <returns>Returns OrderListDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderListDto>> GetAll()
        {
            var query = new GetOrderListQuery { };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets the list of filtered orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /order
        /// </remarks>
        /// <returns>Returns OrderLookupBySpecDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet("filteredorders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderLookupBySpecDto>> GetAllFiltered(string? bookTittle,
            string? name,
            string? lastName,
            string? middleName,
            DateTimeOffset plannedDate1,
            DateTimeOffset plannedDate2,
            DateTimeOffset orderDate1,
            DateTimeOffset orderDate2,
            OrderStatus orderStatus,
            bool bookTittleSpec,
            bool bookAuthorSpec,
            bool plannedReturnDateSpec,
            bool orderDateSpec,
            bool orderStatusSpec)
        {
            FullName authorFullName = new FullName(name, lastName, middleName);

            var query = new GetOrderListBySpecQuery(
                bookTittle,
                authorFullName,
                plannedDate1,
                plannedDate2,
                orderDate1,
                orderDate2,
                orderStatus,
                bookTittleSpec,
                bookAuthorSpec,
                plannedReturnDateSpec,
                orderDateSpec,
                orderStatusSpec);

            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Creates the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /order
        /// {
        ///     orderId: "rentered order Id",
        ///     renterId: "renter Id",
        ///     orderdate: "order date",
        ///     plannedReturnDate: "planned order return date",
        ///     ordertitle:  "rentered order title",
        ///     orderauthor: "rentered order author",
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

        /// <summary>
        /// Closes the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /order/close
        /// {
        ///     "id": "order ID",
        ///     "orderStatus": "order status",
        ///     "comment": "comment",
        ///     "bookCondition": "book condition"
        /// }
        /// </remarks>
        /// <param name="closeOrderModel">CloseOrderModel object</param>
        /// <returns>Returns NoContent</returns>
        [HttpPut("close")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CloseOrder([FromBody] CloseOrderModel closeOrderModel)
        {
            var command = _mapper.Map<CloseOrderCommand>(closeOrderModel);

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
