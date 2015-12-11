namespace Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Format { get; set; }

        public byte[] Content { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
