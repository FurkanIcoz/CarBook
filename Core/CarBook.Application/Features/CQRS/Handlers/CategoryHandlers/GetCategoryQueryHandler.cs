using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x=> new GetCategoryQueryResult
            {
                CategoryID = x.CategoryID,
                Name = x.Name,
            }).ToList();
        }
    }
}
