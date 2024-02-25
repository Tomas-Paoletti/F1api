using f1api.Models;
using f1api.Service;
using f1api.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddHttpClient();
//builder.Services.AddSingleton<IConfiguration>();



builder.Services.AddDbContext<F1Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("F1"));
});


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
