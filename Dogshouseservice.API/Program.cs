using AspNetCoreRateLimit;
using Dogshouseservice.API;
using Dogshouseservice.API.Repositories;
using Dogshouseservice.API.Repositories.Interfaces;
using Dogshouseservice.API.Services;
using Dogshouseservice.API.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(0, 1);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ApiVersionReader = new HeaderApiVersionReader("ApiVersion");
});

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer("Server=localhost,1433;Database=YourDatabaseName;User Id=sa;Password=YourStrong!Passw0rd;Encrypt=False;")
);
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddTransient<IDogService, DogService>();
builder.Services.AddTransient<IDogRepository, DogRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
