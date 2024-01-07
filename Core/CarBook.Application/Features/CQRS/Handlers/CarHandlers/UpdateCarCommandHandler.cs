using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await repository.GetByIdAsync(command.CarID);
            values.Fuel = command.Fuel;
            values.BigImageUrl = command.BigImageUrl;
            values.Km = command.Km;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Transmision = command.Transmision;
            values.Seat = command.Seat;
            values.Model = command.Model;
            values.Fuel = command.Fuel;
            values.Luggage = command.Luggage;
            await repository.UpdateAsync(values);
        }
    }
}
