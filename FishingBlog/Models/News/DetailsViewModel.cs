using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingBlog.Models.News
{
    public class DetailsViewModel
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public string Sections { get; set; }
    }
}
