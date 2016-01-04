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

<<<<<<< HEAD
        bool AddCar(string name, int hoursePower, CarType brand, string url);

=======
        Car PostCar(string name, int horsePower, float fuelConsuption, int kilometers, decimal price, string constructionYear, CarType type);

        void AddImage(int carId, string imagePath);
>>>>>>> cebda9d7293e7af970ab42d1af84e3ef11a7e6c1
    }
}
