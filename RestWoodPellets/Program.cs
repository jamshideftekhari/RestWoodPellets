using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using RestWoodPellets.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WoodPalletContext>(opt => opt.UseInMemoryDatabase("WoodPalletList"));
builder.Services.AddDbContext<WPConsContext>(opt => opt.UseInMemoryDatabase("WPList"));
builder.Services.AddDbContext<WPContextSql>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("WoodContext")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
