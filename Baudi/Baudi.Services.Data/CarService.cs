using Baudi.Services.Data.Contracts;
using System.Linq;
using Data.Models;
using Data.Repositories;
using System;
using System.IO;
using ConvertImageFileToByteArray;

namespace Baudi.Services.Data
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> cars;


        public CarService(IRepository<Car> cars)
        {
            this.cars = cars;
        }

        public void AddImage(int carId, string imagePath)
        {
            var imageAsBytes = ImageConverter.ConvertFileToByte(imagePath);

            var car = this.cars.GetById(carId);
            car.Images.Add(new Image
            {
                CarId = carId,
                Content = imageAsBytes
            });

            this.cars.Update(car);
            this.cars.SaveChanges();
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

<<<<<<< HEAD
        public bool AddCar(string name, int hoursePower, CarType brand, string url)
        {
            this.cars.Add(new Car()
            {
                Name = name,
                HoursePower = hoursePower,
                Brand = brand,
                ImageUrl = url
            });

            this.cars.SaveChanges();

            return true;
        }
=======
        public Car PostCar(string name, int horsePower, float fuelConsumption, int kilometers, decimal price, string constructionYear, CarType type)
        {
            var cartoAdd = new Car
            {
                Name = name,
                HoursePower = horsePower,
                FuelConsumption = fuelConsumption,
                Kilometers = kilometers,
                Price = price,
                ConstructionYear = constructionYear,
                Brand = type
            };

            this.cars.Add(cartoAdd);
            this.cars.SaveChanges();

            return cartoAdd;


        }

>>>>>>> cebda9d7293e7af970ab42d1af84e3ef11a7e6c1
    }
}
