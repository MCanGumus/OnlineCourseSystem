using CatalogService.Api;
using CatalogService.Api.Features.Categories;
using CatalogService.Api.Options;
using CatalogService.Api.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExtension();

builder.Services.AddCommonService(typeof(CatalogAssembly));

var app = builder.Build();

app.AddCategoryGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
