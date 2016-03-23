using Baudi.Services.Data.Contracts;
using System.Linq;
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
                Brand = type,
                Image = image
            };

            this.cars.Add(cartoAdd);
            this.cars.SaveChanges();

            return cartoAdd;
        }
    }
}
