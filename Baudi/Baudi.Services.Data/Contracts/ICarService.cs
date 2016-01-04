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

        bool AddCar(string name, int hoursePower, CarType brand, string url);

    }
}
