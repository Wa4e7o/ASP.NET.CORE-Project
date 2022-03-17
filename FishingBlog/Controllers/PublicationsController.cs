namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Data.Models;
    using FishingBlog.Infrastructure;
    using FishingBlog.Models.Publications;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class PublicationsController : Controller
    {
        private readonly FishingBlogDbContext data;

        public PublicationsController(FishingBlogDbContext data)
           => this.data = data;


        [Authorize]
        public IActionResult Add()
        {
            if (!this.UserIsAdministrator())
            {
                return RedirectToAction(nameof(AdministratorsController.Become), "Administrators");
            }

            return View(new AddPublicationFormModel
            {
                Sections = this.GetTopicCategories
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPublicationFormModel publication)
        {
            var adminId = this.data
                .Administrators
                .Where(a => a.UserId == this.User.GetId())
                .Select(a => a.Id)
                .FirstOrDefault();

            if (adminId == 0)
            {
                return RedirectToAction(nameof(AdministratorsController.Become), "Administrators");
            }


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
                TopicId = publication.TopicId,
                AdminId = adminId
            };

            this.data.Publications.Add(publicationData);

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }


        public IActionResult All(string searchTerm)
        {

            var publicationsQuery = this.data.Publications.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                publicationsQuery = publicationsQuery.Where(p =>
                p.Title.ToLower().Contains(searchTerm.ToLower()) ||
                p.Description.ToLower().Contains(searchTerm.ToLower()));
            }
            var publications = publicationsQuery
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
            return View(new AllPublicationsQueryModel
            {
                Publications = publications,
                SearchTerm = searchTerm
            });
        }

        public IActionResult AllNewsPage() => View(AllPublicationsQuery(1));

        public IActionResult AllAdvices() => View(AllPublicationsQuery(2));

        public IActionResult AllSpots() => View(AllPublicationsQuery(3));

        public IActionResult AllStories() => View(AllPublicationsQuery(4));

        private bool UserIsAdministrator()
        => this.data
                .Administrators
                .Any(a => a.UserId == this.User.GetId());

        private IEnumerable<PublicationCategoryViewModel> GetTopicCategories
           => this.data
            .Topics
            .Select(t => new PublicationCategoryViewModel
            {
                Id = t.Id,
                Title = t.Title
            })
            .ToList();

        private List<PublicationListingViewModel> AllPublicationsQuery(int numCategory)
        {

            var publications = this.data
                .Publications
                .OrderByDescending(p => p.Id)
                 .Where(p => p.TopicId == numCategory)
                 .Select(p => new PublicationListingViewModel
                 {
                     Id = p.Id,
                     Title = p.Title,
                     Description = p.Description,
                     ImageUrl = p.ImageUrl,
                     Sections = p.Topic.Title
                 })
                 .ToList();

            return publications;
        }
    }
}

