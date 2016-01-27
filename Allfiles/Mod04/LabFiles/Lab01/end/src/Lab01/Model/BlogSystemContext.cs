using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01.Model
{
    public class BlogSystemContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("BlogPosts");
            modelBuilder.Entity<Post>().Property(s => s.Title).IsRequired();
        }
    }
}
