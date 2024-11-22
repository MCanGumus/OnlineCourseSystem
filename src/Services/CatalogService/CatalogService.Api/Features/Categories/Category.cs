﻿using CatalogService.Api.Features.Courses;
using CatalogService.Api.Repositories;

namespace CatalogService.Api.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Course>? Courses { get; set; }
    }
}
