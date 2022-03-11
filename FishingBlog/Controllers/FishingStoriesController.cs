namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Models.FishingStories;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class FishingStoriesController : Controller
    {
        private readonly FishingBlogDbContext data;

        public FishingStoriesController(FishingBlogDbContext data)
        {
            this.data = data;
        }

        public IActionResult AllStories()
        {
            var publications = this.data
                 .Publications
                 .OrderByDescending(p => p.Id)
                 .Where(p => p.TopicId == 4)
                 .Select(p => new FishingStoriesListingViewModel
                 {
                     Id = p.Id,
                     Title = p.Title,
                     Description = p.Description,
                     ImageUrl = p.ImageUrl,
                     Sections = p.Topic.Title
                 })
                 .ToList();


            return View(publications);
        }
    }
}
