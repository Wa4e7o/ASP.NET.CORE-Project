namespace FishingBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Administrator;

    public class Administrator
    {

        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Publication> Publications { get; init; } = new List<Publication>();

    }
}
