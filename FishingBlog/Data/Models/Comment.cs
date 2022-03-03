namespace FishingBlog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Comment
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string NickName { get; set; }

        //description.length>0
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string CommentText { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
