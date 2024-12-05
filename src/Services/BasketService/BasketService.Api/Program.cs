using BasketService.Api;
using BasketService.Api.Features.Baskets;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddVersioningExtension();

builder.Services.AddCommonService(typeof(BasketAssembly));
builder.Services.AddScoped<BasketService.Api.Features.Baskets.BasketService>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConfiguration");
});

var app = builder.Build();

app.AddBasketGroupEndpointExt(app.AddVersionSetExtension());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
