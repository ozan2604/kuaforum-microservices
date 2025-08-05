using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistence;
using System.Security.Claims;
using System.Text;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer("Admin" ,options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true, // tokený kim daðýtýyor (biz)
            ValidateAudience = true, // tokený kim kullanýyor 
            ValidateLifetime = true, // tokenýn geçerlilik süresi doðrular
            ValidateIssuerSigningKey = true, // tokenýn bizim ürettiðimize dair bir key

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            // tokenýn süresi geçerli mi

            NameClaimType = ClaimTypes.Name,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionsHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>()); 
app.UseHttpsRedirection();



app.UseAuthentication(); // kendimiz ekliyoruz
app.UseAuthorization();

app.MapControllers();

app.Run();
