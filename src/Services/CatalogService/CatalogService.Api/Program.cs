using Asp.Versioning.Builder;
using CatalogService.Api;
using CatalogService.Api.Features.Categories;
using CatalogService.Api.Features.Courses;
using CatalogService.Api.Options;
using CatalogService.Api.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shared.Extensions;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExtension();

builder.Services.AddCommonService(typeof(CatalogAssembly));

builder.Services.AddVersioningExtension();

var app = builder.Build();

app.AddSeedData().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data has been saved successfully.");
});

app.AddCategoryGroupEndpointExt(app.AddVersionSetExtension());
app.AddCourseGroupEndpointExt(app.AddVersionSetExtension());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
