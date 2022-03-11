namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Models.News;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class NewsController : Controller
    {

        private readonly FishingBlogDbContext data;

        public NewsController(FishingBlogDbContext data)
        {
            this.data = data;
        }

        public IActionResult AllNewsPage()
        {
            var newsPublication = this.data
                 .Publications
                 .OrderByDescending(p => p.Id)
                 .Where(p => p.TopicId == 1)
                 .Select(p => new NewsListingViewModel
                 {
                     Id = p.Id,
                     Title = p.Title,
                     Description = p.Description,
                     ImageUrl = p.ImageUrl,
                     Sections = p.Topic.Title
                 })
                 .ToList();
            

            return View(newsPublication);
        }

    }
}
