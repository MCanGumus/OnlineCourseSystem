using CatalogService.Api.Features.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CatalogService.Api.Repositories
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Id).ValueGeneratedNever();
           builder.Property(x => x.Name).HasMaxLength(100);
           builder.Ignore(x => x.Courses);
        }
    }
}
