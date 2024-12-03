using CatalogService.Api.Features.Categories;
using CatalogService.Api.Features.Courses;
using System.Runtime.CompilerServices;

namespace CatalogService.Api.Repositories
{
    public static class SeedData
    {
        public async static Task AddSeedData(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            if (!context.Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new() {Id = NewId.NextSequentialGuid(), Name = "Development"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "Business"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "IT & Software"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "Office Productivity"},
                    new() {Id = NewId.NextSequentialGuid(), Name = "Personal Development"},
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            if (!context.Courses.Any())
            {
                var category = await context.Categories.FirstAsync();

                var randomUserId = NewId.NextGuid();

                List<Course> courses = new List<Course>
                {
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "C#",
                        Description = "C# Course",
                        Price = 100,
                        UserId = randomUserId,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new()
                        {
                            Duration = 10,
                            EducatorName = "Can GÜMÜŞ",
                            Rating = 5
                        },
                        CategoryId = category.Id,
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Java",
                        Description = "Java Course",
                        Price = 80,
                        UserId = randomUserId,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new()
                        {
                            Duration = 8,
                            EducatorName = "Can GÜMÜŞ",
                            Rating = 3
                        },
                        CategoryId = category.Id,
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Python",
                        Description = "Python Course",
                        Price = 100,
                        UserId = randomUserId,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new()
                        {
                            Duration = 5,
                            EducatorName = "Can GÜMÜŞ",
                            Rating = 2
                        },
                        CategoryId = category.Id,
                    },
                };

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }
        }
    }
}
