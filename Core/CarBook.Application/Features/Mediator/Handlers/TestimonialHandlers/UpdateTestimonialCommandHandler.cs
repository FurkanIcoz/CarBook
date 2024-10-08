﻿using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.TestimonialID);

            values.Comment = request.Comment;
            values.Name = request.Name;
            values.Title = request.Title;
            values.ImageUrl = request.ImageUrl;

            await repository.UpdateAsync(values);
        }
    }
}
