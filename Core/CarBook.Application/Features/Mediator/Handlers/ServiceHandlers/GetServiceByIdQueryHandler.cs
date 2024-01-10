using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                Description = value.Description,
                ServiceID = value.ServiceID,
                Title = value.Title,
                IconUrl = value.IconUrl
            };
        }
    }
}
