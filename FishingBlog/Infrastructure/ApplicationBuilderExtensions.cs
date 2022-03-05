namespace FishingBlog.Infrastructure
{
    using FishingBlog.Data;
    using FishingBlog.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            // This is the method that takes care of preparing the database.

            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<FishingBlogDbContext>();

            data.Database.Migrate();

            SeedTopics(data);

            return app;
        }

        private static void SeedTopics(FishingBlogDbContext data)
        {
            if (data.Topics.Any())
            {
                return;
            }

            data.Topics.AddRange(new[]
            {
              new Topic{ Title = "News" },
              new Topic{ Title = "Fishing Advice" },
              new Topic{ Title = "Fishing spots" },
              new Topic{ Title = "Fishing stories" },
              new Topic{ Title = "How to catch"},
              new Topic{ Title ="Shop"}
            });

            data.SaveChanges();
        }
    }
}
