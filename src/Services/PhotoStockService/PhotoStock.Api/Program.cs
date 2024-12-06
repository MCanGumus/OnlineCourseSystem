using Microsoft.AspNetCore.Mvc;
using PhotoStock.Api;
using PhotoStock.Api.Features;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonService(typeof(PhotoStockAssembly));

builder.Services.AddVersioningExtension();

builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN"; // CSRF token için özel bir header kullanabilirsiniz
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
});

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();
app.AddPhotoStockGroupEndpointExt(app.AddVersionSetExtension());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

