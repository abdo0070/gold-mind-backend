using GoldenMind;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var DB_URI = builder.Configuration.GetConnectionString("DB_URI");
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(DB_URI));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddCors(options =>
{
        options.AddDefaultPolicy(policy => {
        policy.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod(); });
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("PublicPolicy", policy =>
    {
        policy.AllowAnyOrigin().WithMethods("*").AllowAnyHeader();
    });
});
// JWT Bearer

var app = builder.Build();
app.UseCors();
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
