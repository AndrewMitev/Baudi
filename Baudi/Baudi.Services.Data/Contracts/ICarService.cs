using System.Linq;
using Data.Models;

namespace Baudi.Services.Data.Contracts
{
    public interface ICarService
    {
        IQueryable<Car> GetAll(int page = 1, int size = 10,int brand = -1);

        IQueryable<Car> GetCheapest(int page = 1, int size = 10, int brand = -1);

        IQueryable<Car> GetMostExpensive(int page = 1, int size = 10, int brand = -1);

        IQueryable<Car> GetNewest(int page = 1, int size = 10, int brand = -1);

        IQueryable<Car> GetOldest(int page = 1, int size = 10, int brand = -1);

        Car PostCar(string name, int horsePower, float fuelConsuption, int kilometers, decimal price, string constructionYear, string image, CarType type);
    }
}
