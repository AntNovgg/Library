using CatalogService.Application.Queries.GetBookDetails;
using CatalogService.Application.Queries.GetBookList;
using CatalogService.Application.Commands.AddBook;
using CatalogService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CatalogService.Application.Commands.UpdateBook;
using CatalogService.Application.Commands.DeleteBook;
using CatalogService.Application.Queries.GetBookListBySpec;
using CatalogService.Domain.Aggregates;

namespace CatalogService.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : BaseController

    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of books
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book
        /// </remarks>
        /// <returns>Returns BookListDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookListDto>> GetAll()
        {
            var query = new GetBookListQuery{};
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets the list of filtered books
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book
        /// </remarks>
        /// <returns>Returns BookLookupBySpecDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet("filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookLookupBySpecDto>> GetAllFiltered(string? title,
            string? author,
            Genre genre,
            bool titleSpec,
            bool authorSpec,
            bool genreSpec,
            bool availabilitySpec)
        {
            var query = new GetBookListBySpecQuery(
                title,
                author,
                genre,
                titleSpec,
                authorSpec,
                genreSpec,
                availabilitySpec);

            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets the book by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/D4837E56-F064-450A-84E6-983352B2E9C1
        /// </remarks>
        /// <param name="id">Book id (guid)</param>
        /// <returns>Returns BookDetailsDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDetailsDto>> Get(Guid id)
        {
            var query = new GetBookDetailsQuery
            {                
                Id = id
            };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Creates the book
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /book
        /// {
        ///     title: "book title",
        ///     author: "book author",
        ///     genre: "book genre",
        ///     bookcondition: "book condition",
        ///     isavailable:  "book availability"
        /// }
        /// </remarks>
        /// <param name="addBookModel">AddBookModel object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> AddBook([FromBody] AddBookModel addBookModel)
        {
            var command = _mapper.Map<AddBookCommand>(addBookModel);
            
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /book
        /// {
        ///     title: "updated book title",
        ///     author: "updated book author",
        ///     genre: "updated book genre",
        ///     bookcondition: "updated book condition",
        ///     isavailable:  "updated book availability"
        /// }
        /// </remarks>
        /// <param name="updateBookModel">UupdateBookModel object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBookModel updateBookModel)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookModel);

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the book by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /book/5D1FF653-2301-438F-8E31-25FF55D411BD
        /// </remarks>
        /// <param name="id">Id of the book (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id,                
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
