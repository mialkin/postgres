using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Postgres.Api.Database;
using Postgres.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BloggingContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5433;Database=my_db;Username=my_user;Password=my_pw"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.MigrateDbAsync();

app.Run();