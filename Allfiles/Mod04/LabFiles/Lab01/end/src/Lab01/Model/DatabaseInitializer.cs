using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01.Model
{
    public class DatabaseInitializer
    {
        BlogSystemContext _context;
        public DatabaseInitializer(BlogSystemContext context)
        {
            _context = context;
        }

        public async Task Initialize()
        {
            // Make sure the database exists (if not, then it will be created)
            _context.Database.EnsureCreated();

            // Populate the database with some data
            if (!_context.Blogs.Any())
            {
                _context.Blogs.AddRange(
                    new Blog
                    {
                        Name = "Blog 1",
                        Posts = new List<Post> {
                            new Post {Title = "Post 1", PublishDate = DateTime.Today } }
                    },
                    new Blog
                    {
                        Name = "Blog 2",
                        Posts = new List<Post> {
                                new Post {Title = "Post 2", PublishDate = DateTime.Today },
                                new Post {Title = "Post 3", PublishDate = DateTime.Today } }
                    });

                await _context.SaveChangesAsync();
            }
        }
    }
}
