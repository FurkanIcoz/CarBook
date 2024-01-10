using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator mediator;

        public SocialMediasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var value = await mediator.Send(new GetSocialMediaQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok("Sosyal Medya Basariyla Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok("Sosyal Medya Basariyla Guncellendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal Medya Basariyla Silindi");
        }
    }
}
