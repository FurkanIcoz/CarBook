using CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
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
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository< FooterAddress> repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                FooterAddressID = x.FooterAddressID
            }).ToList();
        }
    }
}

