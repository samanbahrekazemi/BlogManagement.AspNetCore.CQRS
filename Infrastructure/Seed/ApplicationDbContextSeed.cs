using Core.Models;
using Infrastructure.Context;

namespace Infrastructure.Seed
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            try
            {
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>
                    {
                        new Category { Name = "Technology" },
                        new Category { Name = "Programming" },
                        new Category { Name = "Learning" },
                        new Category { Name = "Art" },
                        new Category { Name = "Sports" },
                        new Category { Name = "Football" }
                    };

                    await context.Categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }

                if (!context.Tags.Any())
                {
                    var tags = new List<Tag>
                    {
                        new Tag { Name = "C#" },
                        new Tag { Name = "ASP.NET Core" },
                        new Tag { Name = "JavaScript" },
                        new Tag { Name = "React" },
                        new Tag { Name = "Angular" },
                        new Tag { Name = "Vue Js" },
                        new Tag { Name = "Linux" },
                        new Tag { Name = "Docker" },
                        new Tag { Name = "CI/CD" },
                        new Tag { Name = "SOLID" },
                        new Tag { Name = "Clean Code" },
                        new Tag { Name = "EF" },
                        new Tag { Name = "SQL Server" },
                        new Tag { Name = "PostgreSQL" },
                        new Tag { Name = "MangoDB" },
                        new Tag { Name = "GitLab" },
                        new Tag { Name = "GitHub" },
                    };

                    await context.Tags.AddRangeAsync(tags);
                    await context.SaveChangesAsync();
                }

                if (!context.Posts.Any())
                {
                    var posts = new List<Post>
                    {
                        new Post { Title = "Introduction to ASP.NET Core", Content = "This is an introduction to ASP.NET Core.", CategoryId = 1 },
                        new Post { Title = "Building a Web API with ASP.NET Core", Content = "This is a tutorial on building a Web API with ASP.NET Core.", CategoryId = 1 },
                        new Post { Title = "React Components", Content = "This is a tutorial on React components.", CategoryId = 2 },
                        new Post { Title = "Political News Update", Content = "This is an update on political news.", CategoryId = 3 }
                    };

                    await context.Posts.AddRangeAsync(posts);
                    await context.SaveChangesAsync();
                }

                if (!context.PostTags.Any())
                {
                    var postTags = new List<PostTag>
                    {
                        new PostTag { PostId = 1, TagId = 1 },
                        new PostTag { PostId = 1, TagId = 2 },
                        new PostTag { PostId = 2, TagId = 1 },
                        new PostTag { PostId = 2, TagId = 2 },
                        new PostTag { PostId = 2, TagId = 3 },
                        new PostTag { PostId = 3, TagId = 3 },
                        new PostTag { PostId = 3, TagId = 4 }
                    };

                    await context.PostTags.AddRangeAsync(postTags);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
