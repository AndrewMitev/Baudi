using Baudi.Services.Data.Contracts;
using System.Linq;
using Data.Models;
using Data.Repositories;
using System;

namespace Baudi.Services.Data
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> cars;


        public CarService(IRepository<Car> cars)
        {
            this.cars = cars;
        }

        public IQueryable<Car> GetAll(int page = 1, int pageSize = 10, int brand = -1)
        {
            return this.cars
                       .All()
                       .Where(c => brand == -1 ? true : c.Brand == (CarType)brand)
                       .OrderBy(c => c.Name)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize);
        }

        public IQueryable<Car> GetNewest(int page = 1, int pageSize = 10, int brand = -1)
        {

            return this.cars
                      .All()
                      .Where(c => brand == -1 ? true : c.Brand == (CarType)brand)
                      .OrderByDescending(c => c.ConstructionYear)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize);

        }

        public IQueryable<Car> GetOldest(int page = 1, int pageSize = 10, int brand = -1)
        {
            return this.cars
                    .All()
                    .Where(c => brand == -1 ? true : c.Brand == (CarType)brand)
                    .OrderBy(c => c.ConstructionYear)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }

        public IQueryable<Car> GetCheapest(int page = 1, int pageSize = 10, int brand = -1)
        {
            return this.cars
                      .All()
                      .Where(c => brand == -1 ? true : c.Brand == (CarType)brand)
                      .OrderBy(c => c.Price)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize);
        }

        public IQueryable<Car> GetMostExpensive(int page = 1, int pageSize = 10, int brand = -1)
        {
            return this.cars
                      .All()
                      .Where(c => brand == -1 ? true : c.Brand == (CarType)brand)
                      .OrderByDescending(c => c.Price)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize);
        }
        public Car PostCar(string name, int horsePower, float fuelConsumption, int kilometers, decimal price, string constructionYear, string image, CarType type)
        {
            var cartoAdd = new Car
            {
                Name = name,
                HoursePower = horsePower,
                FuelConsumption = fuelConsumption,
                Kilometers = kilometers,
                Price = price,
                ConstructionYear = constructionYear,
                Brand = (CarType)type,
                Image = image
            };

            this.cars.Add(cartoAdd);
            this.cars.SaveChanges();

            return cartoAdd;
        }
    }
}
