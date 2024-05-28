using AutoMapper;
using CatalogService.Application.Authors.Commands.AddAuthor;
using CatalogService.Application.Authors.Commands.DeleteAuthor;
using CatalogService.Application.Authors.Commands.UpdateAuthor;
using CatalogService.Application.Authors.Queries.GetAuthorDetails;
using CatalogService.Application.Authors.Queries.GetAuthorList;
using CatalogService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;
        public AuthorController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Creates the author
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /author
        /// {
        ///     name: "author name",
        ///     lastname: "author lastname",
        ///     middlename: "author middlename"       
        /// }
        /// </remarks>
        /// <param name="addAuthorModel">AddAuthorModel object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> AddAuthor([FromBody] AddAuthorModel addAuthorModel)
        {
            var command = _mapper.Map<AddAuthorCommand>(addAuthorModel);

            var authorId = await Mediator.Send(command);
            return Ok(authorId);
        }

        /// <summary>
        /// Gets the list of authors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /author
        /// </remarks>
        /// <returns>Returns AuthorListDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthorListDto>> GetAll()
        {
            var query = new GetAuthorListQuery { };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Gets the author by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /author/D4837E56-F064-450A-84E6-983352B2E9C1
        /// </remarks>
        /// <param name="id">Author id (guid)</param>
        /// <returns>Returns AuthorDetailsDto</returns>
        /// <response code="200">Success</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthorDetailsDto>> Get(Guid id)
        {
            var query = new GetAuthorDetailsQuery
            {
                Id = id
            };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Updates the author
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /author
        /// {
        ///     name: "author name",
        ///     lastname: "author lastname",
        ///     middlename: "author middlename"       
        /// }
        /// </remarks>
        /// <param name="updateAuthorModel">UpdateAuthorModel object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAuthor([FromBody] UpdateAuthorModel updateAuthorModel)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorModel);

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the author by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /author/5D1FF653-2301-438F-8E31-25FF55D411BD
        /// </remarks>
        /// <param name="id">Id of the author (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
