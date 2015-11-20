namespace Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Car
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
