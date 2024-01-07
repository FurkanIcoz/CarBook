using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID,
                Name = value.Name,
            };
        }
    }
}
