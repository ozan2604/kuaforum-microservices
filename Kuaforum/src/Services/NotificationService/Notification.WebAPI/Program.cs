using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Notification.WebAPI;
using MassTransit;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNotificationServices();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(
            builder.Configuration["RabbitMQ:Host"],
            ushort.Parse(builder.Configuration["RabbitMQ:Port"]), "/", h =>
             {
                 h.Username(builder.Configuration["RabbitMQ:Username"]);
                 h.Password(builder.Configuration["RabbitMQ:Password"]);
             });
    });
});



builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true, // token kim datyor (biz)
            ValidateAudience = true, // token kim kullanyor
            ValidateLifetime = true, // tokenn geerlilik sresi dorular
            ValidateIssuerSigningKey = true, // tokenn bizim rettiimize dair bir key

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            // tokenn sresi geerli mi
            ClockSkew = TimeSpan.Zero, // tokenn sresi geerli mi
            NameClaimType = ClaimTypes.Name, 
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // kendimiz ekliyoruz
app.UseAuthorization();

app.MapControllers();

app.Run();
