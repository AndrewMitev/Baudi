using Baudi.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;

namespace Baudi.Services.Data
{
   public class CarService : ICarService
    {
        private readonly IRepository<Car> cars;


        public CarService(IRepository<Car> cars)
        {
            this.cars = cars;
        }

        public IQueryable<Car> GetAll(int page = 0, int pageSize = 10)
        {
            return this.cars
                       .All()
                       .OrderBy(c => c.Name)
                       .Skip(page * pageSize)
                       .Take(pageSize);
        }

        public IQueryable<Car> GetByYear(int page = 0, int pageSize = 10)
        {
            return this.cars
                       .All()
                       .OrderByDescending(c => c.ConstructionYear)
                       .Skip(page * pageSize)
                       .Take(pageSize);
        }

        public IQueryable<Car> GetCheapest(int page = 0, int pageSize = 10)
        {
            return this.cars
                      .All()
                      .OrderBy(c => c.Price)
                      .Skip(page * pageSize)
                      .Take(pageSize);
        }

        public IQueryable<Car> GetMostExpensive(int page = 0, int pageSize = 10)
        {
            return this.cars
                      .All()
                      .OrderByDescending(c => c.Price)
                      .Skip(page * pageSize)
                      .Take(pageSize);
        }
    }
}
