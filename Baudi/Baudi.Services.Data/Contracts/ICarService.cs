using System.Linq;
using Data.Models;

namespace Baudi.Services.Data.Contracts
{
    public interface ICarService
    {
        IQueryable<Car> GetAll(int page = 0, int size = 10);

        IQueryable<Car> GetCheapest(int page = 0, int size = 10);

        IQueryable<Car> GetMostExpensive(int page = 0, int size = 10);

        IQueryable<Car> GetByYear(int page = 0, int size = 10);

        Car PostCar(string name, int horsePower, float fuelConsuption, int kilometers, decimal price, string constructionYear, string image, CarType type);
    }
}
