namespace FishingBlog.Data
{
    using FishingBlog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FishingBlogDbContext : IdentityDbContext
    {

        public FishingBlogDbContext(DbContextOptions<FishingBlogDbContext> options)
            : base(options)
        {

        }

        public DbSet<Topic> Topics { get; init; }

        public DbSet<Publication> Publications { get; init; }

        public DbSet<Comment> Comments { get; init; }

        public DbSet<Cart> Carts { get; init; }

        public DbSet<Product> Products { get; init; }

        public DbSet<News> Newses { get; init; } 

        public DbSet<Administrator> Administrators { get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Publication>()
               .HasOne(t => t.Topic)
               .WithMany(p => p.Publications)
               .HasForeignKey(p => p.TopicId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Comment>()
               .HasOne(p => p.Publication)
               .WithMany(c => c.Comments)
               .HasForeignKey(c => c.PublicationId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Product>()
               .HasOne(c => c.Cart)
               .WithMany(p => p.Products)
               .HasForeignKey(p => p.CartId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Publication>()
                .HasOne(p => p.Administrator)
                .WithMany(a => a.Publications)
                .HasForeignKey(p => p.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Administrator>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Administrator>(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}