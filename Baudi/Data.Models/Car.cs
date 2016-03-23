namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public Car()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int HoursePower { get; set; }

        public float FuelConsumption { get; set; }

        public int Kilometers { get; set; }

        public decimal Price { get; set; }

        [Required]
        public CarType Brand { get; set; }

        public string ConstructionYear { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
