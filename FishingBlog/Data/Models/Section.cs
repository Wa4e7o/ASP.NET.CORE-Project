namespace FishingBlog.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Section
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Publication> Publications { get; set; } = new List<Publication>();
    }
}
