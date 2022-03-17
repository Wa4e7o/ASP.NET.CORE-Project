namespace FishingBlog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Product;

    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; init; }
    }
}
