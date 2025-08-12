using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Notification.WebAPI;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNotificationServices();

builder.Services.AddAuthorization(//ops => ops.AddPolicy("AdminPolicy",policy => policy.RequireClaim("Role", "Admin"))
); //burasý deðiþecek
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true, // tokený kim daðýtýyor (biz)
            ValidateAudience = true, // tokený kim kullanýyor 
            ValidateLifetime = true, // tokenýn geçerlilik süresi doðrular
            ValidateIssuerSigningKey = true, // tokenýn bizim ürettiðimize dair bir key

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            // tokenýn süresi geçerli mi
            ClockSkew = TimeSpan.Zero, // tokenýn süresi geçerli mi
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
   /// .RequireAuthorization("AdminPolicy");  //burasý deðiþecek

app.Run();
