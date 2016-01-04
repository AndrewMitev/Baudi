namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        private ICollection<Image> images;

        public Car()
        {
            this.images = new HashSet<Image>();
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

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
