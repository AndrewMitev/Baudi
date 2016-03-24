using AutoMapper.QueryableExtensions;
using Baudi.Services.Data.Contracts;
using Server.Api.Models;
using System.Linq;
using System.Web.Http;

namespace Server.Api.Controllers
{
    public class CarsController : ApiController
    {
        private ICarService cars;

        public CarsController(ICarService carsService)
        {
            this.cars = carsService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetAll(int page = 1, int pageSize = 10, int brand = -1)
        {
            var response = this.cars.GetAll(page, pageSize, brand).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/cars/filteredByPriceLow")]
        public IHttpActionResult GetCheapest(int page = 1, int pageSize = 10, int brand = -1)
        {
            var response = this.cars.GetCheapest(page, pageSize, brand).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/cars/filteredByPriceHigh")]
        public IHttpActionResult GetMostExpensive(int page = 1, int pageSize = 10, int brand = -1)
        {
            var response = this.cars.GetMostExpensive(page, pageSize, brand).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/cars/filteredByYearNewest")]
        public IHttpActionResult GetByYear(int page = 1, int pageSize = 10, int brand = -1)
        {
            var response = this.cars.GetNewest(page, pageSize, brand).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/cars/filteredByYearOldest")]
        public IHttpActionResult GetOldest(int page = 1, int pageSize = 10, int brand = -1)
        {
            var response = this.cars.GetOldest(page, pageSize, brand).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(CarResponseRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return this.BadRequest("Model is invalid");
            }

            var car = this.cars.PostCar(model.Name,
                                        model.HoursePower,
                                        model.FuelConsumption,
                                        model.Kilometers,
                                        model.Price,
                                        model.ConstructionYear,
                                        model.Image,
                                        model.Brand);

            return this.Created("", car.Name);
        }
    }
}
