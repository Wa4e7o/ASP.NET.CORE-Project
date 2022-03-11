namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Models.FishingSpots;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class FishingSpotsController : Controller
    {
        private readonly FishingBlogDbContext data;

        public FishingSpotsController(FishingBlogDbContext data)
        {
            this.data = data;
        }

        public IActionResult AllSpots()
        {
            var publications = this.data
                 .Publications
                 .OrderByDescending(p => p.Id)
                 .Where(p => p.TopicId == 3)
                 .Select(p => new FishingSpotsListingViewModel
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
