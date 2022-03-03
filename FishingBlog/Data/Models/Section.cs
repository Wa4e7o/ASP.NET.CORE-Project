namespace FishingBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Section
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        public IEnumerable<Publication> Publications { get; set; } = new List<Publication>();
    }
}
