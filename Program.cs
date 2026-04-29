using GoldenMind;
using GoldenMind.Auth;
using GoldenMind.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtOptions = new JwtOptions();

builder.Configuration.GetSection("JWT").Bind(jwtOptions);
builder.Services.AddSingleton(jwtOptions);

builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DB_URI")));

builder.Services.AddCors(opt => opt.AddDefaultPolicy(
policy => 
policy.AllowAnyHeader()
.AllowAnyOrigin()
.AllowAnyMethod()
));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(jwtOpt =>
    {
        jwtOpt.Audience = jwtOpt.Audience;
        jwtOpt.Authority = jwtOpt.Authority;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
