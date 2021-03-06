namespace FishingBlog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Comment;

    public class Comment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string NickName { get; set; }

        //description.length>0
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string CommentText { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        public int PublicationId { get; set; }

        public Publication Publication { get; init; }

    }
}
