namespace FishingBlog.Models.News
{

    public class NewsListingViewModel
    {

        public int Id { get; init; }

        public string Title { get; set; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public string Sections { get; set; }

    }
}
