namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Data.Models;
    using FishingBlog.Models.Publications;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class PublicationsController : Controller
    {
        private readonly FishingBlogDbContext data;

        public PublicationsController(FishingBlogDbContext data)
           => this.data = data;


        public IActionResult Add() => View(new AddPublicationFormModel
        {
            Sections = this.GetTopicCategories
        });

        public IActionResult All()
        {
            var publications = this.data
                 .Publications
                 .OrderByDescending(p => p.Id)
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

        [HttpPost]
        public IActionResult Add(AddPublicationFormModel publication)
        {
            if (!this.data.Topics.Any(t => t.Id == publication.TopicId))
            {
                this.ModelState.AddModelError(nameof(publication.TopicId), "Section does not exist");
            }

            if (!ModelState.IsValid)
            {
                publication.Sections = this.GetTopicCategories;

                return View(publication);
            }

            var publicationData = new Publication
            {
                Title = publication.Title,
                Description = publication.Description,
                ImageUrl = publication.ImageUrl,
                PublishedOn = publication.PublishedOn,
                TopicId = publication.TopicId
            };

            this.data.Publications.Add(publicationData);

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<PublicationCategoryViewModel> GetTopicCategories
           => this.data
            .Topics
            .Select(t => new PublicationCategoryViewModel
            {
                Id = t.Id,
                Title = t.Title
            })
            .ToList();
    }
}

