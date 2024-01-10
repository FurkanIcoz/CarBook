using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var value = await mediator.Send(new GetServiceQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await mediator.Send(command);
            return Ok("Hizmet Basariyla Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await mediator.Send(command);
            return Ok("Hizmet Basariyla Guncellendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            await mediator.Send(new RemoveServiceCommand(id));
            return Ok("Hizmet Basariyla Silindi");
        }
    }
}
