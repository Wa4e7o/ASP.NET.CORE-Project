namespace FishingBlog.Controllers
{
    using FishingBlog.Models.Publications;
    using Microsoft.AspNetCore.Mvc;

    public class PublicationsController : Controller
    {
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddPublicationFormModel publication)
        {
            return View();
        }
    }
}
