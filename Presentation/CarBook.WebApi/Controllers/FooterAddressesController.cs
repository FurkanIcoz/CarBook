﻿using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator mediator;

        public FooterAddressesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var value = await mediator.Send(new GetFooterAddressQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Alt Adres Bilgisi Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Alt Adres Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Alt Adres Bilgisi Guncellendi");

        }
    }
}
