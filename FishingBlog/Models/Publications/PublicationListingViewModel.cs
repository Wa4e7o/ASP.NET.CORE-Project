namespace FishingBlog.Models.Publications
{
    public class PublicationListingViewModel
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public string Sections { get; set; }
    }
}
