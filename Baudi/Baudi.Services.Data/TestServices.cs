namespace Baudi.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using global::Data.Repositories;
    using global::Data.Models;

    public class TestServices : ITestServices
    {
        private IRepository<Car> cars;

        public TestServices(IRepository<Car> cars)
        {
            this.cars = cars;
        }

        public IQueryable Get()
        {
            throw new NotImplementedException();
        }
    }
}
