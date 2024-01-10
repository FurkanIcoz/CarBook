using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PricingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var value = await mediator.Send(new GetPricingQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await mediator.Send(command);
            return Ok("Odeme Turu Basariyla Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await mediator.Send(command);
            return Ok("Odeme Turu Basariyla Guncellendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await mediator.Send(new RemovePricingCommand(id));
            return Ok("Odeme Turu Basariyla Silindi");
        }
    }
}
