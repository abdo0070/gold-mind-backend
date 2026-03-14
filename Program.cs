using GoldenMind;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var DB_URI = builder.Configuration.GetConnectionString("DB_URI");
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(DB_URI));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use Database => sql server
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run(); 
