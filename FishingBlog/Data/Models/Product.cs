namespace FishingBlog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Product
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
