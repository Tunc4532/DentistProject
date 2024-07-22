using Dentist.Application.Features.Mediator.Commands.AboutCommands;
using Dentist.Application.Features.Mediator.Commands.CategoryCardCommands;
using Dentist.Application.Features.Mediator.Queries.AboutQueries;
using Dentist.Application.Features.Mediator.Queries.CategoryCardQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCardsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoryCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryCards()
        {
            return Ok(await _mediator.Send(new GetCategoryCardQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryCardById(int id)
        {
            return Ok(await _mediator.Send(new GetCategoryCardByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryCard(CreateCategoryCardCommand command)
        {
            await _mediator.Send(command);
            return Ok("CategoryCard created succesfully");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCategoryCard(UpdateCategoryCardCommand command)
        {
            await _mediator.Send(command);
            return Ok("CategoryCard updated succesfully");
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteCategoryCard(int id)
        {
            await _mediator.Send(new RemoveCategoryCardCommand(id));
            return Ok("CategoryCard deleted succesfully");
        }
    }
}
