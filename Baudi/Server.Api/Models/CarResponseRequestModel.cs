namespace Server.Api.Models
{
    using Data.Models;
    using Infrastructure;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System;

    public class CarResponseRequestModel : IMapFrom<Car>
    {
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public int HoursePower { get; set; }

        public float FuelConsumption { get; set; }

        public int Kilometers { get; set; }

        public decimal Price { get; set; }

        public string ConstructionYear{ get; set; }

        public string Image { get; set; }

        [Required]
        public CarType Brand { get; set; }
    }
}