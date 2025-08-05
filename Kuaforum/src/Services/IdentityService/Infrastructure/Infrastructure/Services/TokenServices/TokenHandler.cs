using Application.Abstractions.TokenServices;
using Application.Dtos;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services.TokenServices
{
    public class TokenHandler : ITokenhandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int second, AppUser appUser)
        {
            Token token = new();

            // securitykeyin simetriğini alıyoruz
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

            // şifrelenmiş kimliği olusturuyoruz
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // token oluşturma ayarlarııı
            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: token.Expiration,  // tokeının süresi bu kadar olacak
                notBefore: DateTime.UtcNow, // token olusturulur olusturulmaz devreye al
                signingCredentials: signingCredentials,  // securety key ise algoritma ile şifrelenmiş yukardaki key olacak
                claims: new List<Claim>
                {
                    new Claim("userId", appUser.Id.ToString()), // claim ekliyoruz
                    new Claim("userName", appUser.UserName),
                    new Claim("email", appUser.Email),
                    new Claim("name", appUser.Name),
                    new Claim("surname", appUser.Surname),
                    new Claim("phoneNumber", appUser.PhoneNumber),
                }
            );

            // Token olusturucu sınıfından bir örnek alalım
            JwtSecurityTokenHandler tokenHandler = new();

            // tokenı stringe çeviriyoruz
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken(); 

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
