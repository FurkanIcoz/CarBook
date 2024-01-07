using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommendHandler
    {
        private readonly IRepository<Banner> repository;

        public UpdateBannerCommendHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await repository.GetByIdAsync(command.BannerID);

            values.Description = command.Description;
            values.VideoDescription = command.VideoDescription;
            values.VideoUrl = command.VideoUrl;
            values.Title = command.Title;
            await repository.UpdateAsync(values);
        }
    }
}
