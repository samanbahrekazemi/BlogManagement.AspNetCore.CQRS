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
                        new Category { Title = "Technology" },
                        new Category { Title = "Programming" },
                        new Category { Title = "Learning" },
                        new Category { Title = "Art" },
                        new Category { Title = "Sports" },
                        new Category { Title = "Football" }
                    };

                    await context.Categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }

                if (!context.Tags.Any())
                {
                    var tags = new List<Tag>
                    {
                        new Tag { Title = "C#" },
                        new Tag { Title = "ASP.NET Core" },
                        new Tag { Title = "JavaScript" },
                        new Tag { Title = "React" },
                        new Tag { Title = "Angular" },
                        new Tag { Title = "Vue Js" },
                        new Tag { Title = "Linux" },
                        new Tag { Title = "Docker" },
                        new Tag { Title = "CI/CD" },
                        new Tag { Title = "SOLID" },
                        new Tag { Title = "Clean Code" },
                        new Tag { Title = "EF" },
                        new Tag { Title = "SQL Server" },
                        new Tag { Title = "PostgreSQL" },
                        new Tag { Title = "MangoDB" },
                        new Tag { Title = "GitLab" },
                        new Tag { Title = "GitHub" },
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
