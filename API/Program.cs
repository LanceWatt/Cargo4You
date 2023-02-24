using API.Domain;
using AutoMapper;
using Cargo4You.Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.ShippingService;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<QuoteProfile>();
});

var mapper = mapperConfig.CreateMapper();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the services with the dependency injection container || Shaped like a boat
builder.Services.AddScoped<IShippingRatesService, ShippingRatesService>();
builder.Services.AddScoped<IParcelSpecificationService, MaltaShipCompany>();
builder.Services.AddScoped<IParcelSpecificationService, Cargo4YouCompany>();
builder.Services.AddScoped<IParcelSpecificationService, ShipFasterCompany>();
builder.Services.AddScoped<ICheapestCompanyCalculator, CheapestCompanyCalculator>();
builder.Services.AddScoped<IShippingCompanyFilter, ViableShippingCompanyFilter>();
builder.Services.AddScoped<IShippingCompanyProvider, ShippingCompanyProvider>();
builder.Services.AddScoped<IQuoteDataRepository, QuoteDataRepository>();
builder.Services.AddScoped<IPackageFactory, PackageFactory>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
