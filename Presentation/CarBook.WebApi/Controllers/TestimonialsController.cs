using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TestimonialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var value = await mediator.Send(new GetTestimonialQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Referans Basariyla Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Referans Basariyla Guncellendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans Basariyla Silindi");
        }
    }
}
