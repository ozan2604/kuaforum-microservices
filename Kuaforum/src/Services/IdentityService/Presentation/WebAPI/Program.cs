using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistence;
using System.Security.Claims;
using System.Text;
using WebAPI.Extensions;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"]);
            h.Password(builder.Configuration["RabbitMQ:Password"]);
        });
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
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
            ClockSkew = TimeSpan.Zero, // tokenýn süresi geçerli mi
            NameClaimType = ClaimTypes.Name,
        };
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionsHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>()); 
app.UseHttpsRedirection();



// app.UseAuthentication(); // kendimiz ekliyoruz
app.UseAuthorization();


app.MapControllers();

app.Run();
