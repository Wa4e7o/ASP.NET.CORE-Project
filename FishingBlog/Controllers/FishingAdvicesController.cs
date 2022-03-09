namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Models.Publications;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class FishingAdvicesController : Controller
    {
        private readonly FishingBlogDbContext data;

        public FishingAdvicesController(FishingBlogDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var publications = this.data
                 .Publications
                 .OrderByDescending(p => p.Id)
                 .Where(p => p.TopicId == 2)
                 .Select(p => new PublicationListingViewModel
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
