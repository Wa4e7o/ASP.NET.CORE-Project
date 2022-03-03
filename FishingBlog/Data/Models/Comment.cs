namespace FishingBlog.Data.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
