
namespace FishingBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        [Required]
        public int Id { get; init; }

        public IEnumerable<Publication> Publications { get; set; } = new List<Publication>();

    }
}

