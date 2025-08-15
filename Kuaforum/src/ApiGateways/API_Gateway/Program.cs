using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;

record LogMessage(string? UserName, string? Role, string? OperationName, string Endpoint, string Method);

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new ()
        {
            ValidateIssuer = true, // tokenı kim dağıtıyor (biz)
            ValidateAudience = true, // tokenı kim kullanıyor 
            ValidateLifetime = true, // tokenın geçerlilik süresi doğrular
            ValidateIssuerSigningKey = true, // tokenın bizim ürettiğimize dair bir key

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, token, parameters) => expires != null ? expires > DateTime.UtcNow : false,
            // tokenın süresi geçerli mi
            ClockSkew = TimeSpan.Zero, // tokenın süresi geçerli mi
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    await next();

    var userName = context.User.FindFirst(ClaimTypes.Name)?.Value;
    var role = context.User.FindFirst(ClaimTypes.Role)?.Value;
    var operationName = context.GetEndpoint()?.DisplayName;
    var endpoint = context.Request.Path.ToString();
    var method = context.Request.Method;

    var logMessage = new LogMessage(userName, role, operationName, endpoint, method);

    try
    {
        var httpClientFactory = context.RequestServices.GetRequiredService<IHttpClientFactory>();
        var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
        var client = httpClientFactory.CreateClient();
        var baseUrl = configuration["ServiceUrls:LogService"];

        if (!string.IsNullOrEmpty(baseUrl))
        {
            await client.PostAsJsonAsync($"{baseUrl}/api/logs", logMessage);
        }
    }
    catch
    {
        // logging failed; ignore
    }
});

app.MapControllers();

await app.UseOcelot(); //Sonda olması önemli
app.UseHttpsRedirection();

app.Run();
