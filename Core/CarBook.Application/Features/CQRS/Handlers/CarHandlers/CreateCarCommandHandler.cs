﻿using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        
        public async Task Handle(CreateCarCommand command)
        {
            await repository.CreateAsync(new Car
            {
                BigImageUrl = command.BigImageUrl,
                BrandID = command.BrandID,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Luggage = command.Luggage,
                Model = command.Model,
                Seat = command.Seat,
                Transmision = command.Transmision,
            });
        }

    }
}
