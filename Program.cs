using AutoMapper;
using f1api.Models;
using f1api.Service;
using f1api.Service.IService;
using F1api.Automappers;
using F1api.Repository;
using F1api.Repository.IRepository;
using F1api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddHttpClient();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();


builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

//builder.Services.AddSingleton<IConfiguration>();



builder.Services.AddDbContext<F1Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("F1"));
});
//Validators
builder.Services.AddScoped<IValidator<Driver>,DriverValidator>();

//Repository
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();





var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;

});
app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.Run();
