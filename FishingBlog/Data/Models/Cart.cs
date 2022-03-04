namespace FishingBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Cart
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public int Id { get; set; }

        public IEnumerable<Product> Products = new List<Product>();

    }
}
