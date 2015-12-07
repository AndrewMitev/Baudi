namespace Server.Api.Models
{
    using Data.Models;
    using Infrastructure;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System;

    public class CarResponseRequestModel : IMapFrom<Car>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int HoursePower { get; set; }

        public float FuelConsumption { get; set; }

        public int Kilometers { get; set; }

        [Required]
        public CarType Brand { get; set; }
    }
}