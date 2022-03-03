using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingBlog.Data
{
    public class FishingBlogDbContext : IdentityDbContext
    {
        public FishingBlogDbContext(DbContextOptions<FishingBlogDbContext> options)
            : base(options)
        {
        }
    }
}
