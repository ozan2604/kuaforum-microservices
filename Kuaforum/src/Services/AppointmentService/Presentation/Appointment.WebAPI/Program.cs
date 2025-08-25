using Appointment.Application;
using Appointment.Persistence;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAppointmentPersistenceServices(builder.Configuration);
builder.Services.AddAppointmentApplicationServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMassTransit(x =>
{    
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"],
            ushort.Parse(builder.Configuration["RabbitMQ:Port"]), "/", h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"]);
            h.Password(builder.Configuration["RabbitMQ:Password"]);
        });
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            ClockSkew = TimeSpan.Zero,
            NameClaimType = System.Security.Claims.ClaimTypes.Name
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
