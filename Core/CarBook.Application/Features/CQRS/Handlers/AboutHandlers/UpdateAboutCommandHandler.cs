﻿using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await repository.GetByIdAsync(command.AboutID);
            values.Description = command.Description;
            values.Title = command.Title;
            values.ImageUrl = command.ImageUrl;

            await repository.UpdateAsync(values);
        }
    }
}
