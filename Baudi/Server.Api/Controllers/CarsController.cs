﻿using AutoMapper.QueryableExtensions;
using Baudi.Services.Data.Contracts;
using Server.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult GetAll(int page = 0, int pageSize = 10)
        {
            var response = this.cars.GetAll(page, pageSize).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("filteredByPriceLow")]
        public IHttpActionResult GetCheapest(int page = 0, int pageSize = 10)
        {
            var response = this.cars.GetCheapest(page, pageSize).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("filteredByPriceHigh")]
        public IHttpActionResult GetMostExpensive(int page = 0, int pageSize = 10)
        {
            var response = this.cars.GetMostExpensive(page, pageSize).ProjectTo<CarResponseRequestModel>();

            if (response == null)
            {
                return this.BadRequest("There is no cars to be shown!");
            }

            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("filteredByYear")]
        public IHttpActionResult GetByYear(int page = 0, int pageSize = 10)
        {
            var response = this.cars.GetByYear(page, pageSize).ProjectTo<CarResponseRequestModel>();

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
                return this.BadRequest("Model is invalid");
            }

            var car = this.cars.PostCar(model.Name,
                                        model.HoursePower,
                                        model.FuelConsumption,
                                        model.Kilometers,
                                        model.Price,
                                        model.ConstructionYear,
                                        model.Brand);


            return this.Created("", car.Name);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult AddImage(int carId, string imagePath)
        {
            this.cars.AddImage(carId, imagePath);

            return this.Ok();
        }
    }
}
