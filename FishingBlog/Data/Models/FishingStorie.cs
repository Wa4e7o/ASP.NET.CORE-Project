
namespace FishingBlog.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FishingStorie
    {
        [Required]
        public int Id { get; set; }

        public IEnumerable<Publication> Publications { get; set; } = new List<Publication>();
    }

}
