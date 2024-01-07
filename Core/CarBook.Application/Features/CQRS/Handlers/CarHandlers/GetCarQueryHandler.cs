using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values  = await repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            { 
                CarID = x.CarID,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmision = x.Transmision,
            }).ToList();
        }
    }
}
