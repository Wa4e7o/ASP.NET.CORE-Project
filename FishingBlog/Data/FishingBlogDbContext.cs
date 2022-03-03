using FishingBlog.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingBlog.Data
{
    public class FishingBlogDbContext : IdentityDbContext
    {
        public DbSet<Topic> Topics { get; init; }
        public DbSet<Publication> Publications { get; init; }
        public DbSet<Comment> Comments { get; init; }
        public DbSet<Cart> Carts { get; init; }
        public DbSet<Product> Products { get; init; }

        public FishingBlogDbContext(DbContextOptions<FishingBlogDbContext> options)
            : base(options)
        {

        }
    }
}
