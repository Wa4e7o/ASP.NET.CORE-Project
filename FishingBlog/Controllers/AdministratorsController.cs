namespace FishingBlog.Controllers
{
    using FishingBlog.Data;
    using FishingBlog.Data.Models;
    using FishingBlog.Infrastructure;
    using FishingBlog.Models.Administrators;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class AdministratorsController : Controller
    {
        private readonly FishingBlogDbContext data;

        public AdministratorsController(FishingBlogDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeAdminFormModel administrator)
        {
            var userId = this.User.GetId();


            var userIsAlreadyAdmin = this.data
                .Administrators
                .Any(a => a.UserId == userId);

            if (userIsAlreadyAdmin)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(administrator);
            }

            var adminData = new Administrator
            {
                Name = administrator.UserName,
                UserId = userId
            };

            this.data.Administrators.Add(adminData);

            this.data.SaveChanges();

            return RedirectToAction("/");
        }
    }
}
