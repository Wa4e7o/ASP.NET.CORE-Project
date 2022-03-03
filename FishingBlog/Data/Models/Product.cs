namespace FishingBlog.Data.Models
{
    using System;

    public class Product
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
