namespace FishingBlog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class Publication
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; } = DateTime.UtcNow;

    }
}
