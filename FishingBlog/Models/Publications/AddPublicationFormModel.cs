namespace FishingBlog.Models.Publications
{
    using System;
    public class AddPublicationFormModel
    {
        public string Title { get; init; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public DateTime PublishedOn { get; init; } = DateTime.UtcNow;

        public int TopicId { get; init; }
    }
}
