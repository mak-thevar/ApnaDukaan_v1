using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAndAuthorizationPOC.BLL
{
    public static class JWTHelper
    {
        public static AuthenticationBuilder AddAndConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                var secret = configuration["JWT:Secret"] ?? "the secret code has to be provided!";
                opt.Audience = configuration["JWT:ValidAudience"];
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateIssuer = configuration["JWT:ValidIssuer"] is not null,
                    ValidateAudience = configuration["JWT:ValidAudience"] is not null,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            });
        }
        public static string GenerateToken(IConfiguration configuration, Dictionary<string, string> payloads)
        {
            var secret = configuration["JWT:Secret"]??"the secret code has to be provided!";
            var issuer = configuration["JWT:ValidIssuer"]??null;
            var aud = configuration["JWT:ValidAudience"]??null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(secret);
            var expiresAt = DateTime.Now.AddDays(30);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = issuer,
                Audience = aud,
                Claims = payloads.ToDictionary(x=>x.Key, x=>(object) x.Value),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
