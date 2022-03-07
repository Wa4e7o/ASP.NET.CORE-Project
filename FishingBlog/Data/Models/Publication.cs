namespace FishingBlog.Data.Models
{
    using System;
    using System.Collections.Generic;
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
        public string PublishedOn { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

    }
}
