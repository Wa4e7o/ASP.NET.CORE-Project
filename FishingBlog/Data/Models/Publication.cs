namespace FishingBlog.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Publication;

    public class Publication
    {

        [Required]
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

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        public int AdminId { get; init; }

        public Administrator Administrator { get; init; }
       
    }
}
