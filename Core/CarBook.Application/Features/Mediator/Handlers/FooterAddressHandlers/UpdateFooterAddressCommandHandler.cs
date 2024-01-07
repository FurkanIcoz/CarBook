using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.FooterAddressID);
            value.Phone = request.Phone;
            value.Address = request.Address;
            value.Description = request.Description;
            value.Email = request.Email;
            await repository.UpdateAsync(value);
        }
    }
}
