namespace FishingBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FishingSpot
    {
        [Required]
        public int Id { get; set; }

        public IEnumerable<Publication> Publications { get; set; } = new List<Publication>();

    }

}
