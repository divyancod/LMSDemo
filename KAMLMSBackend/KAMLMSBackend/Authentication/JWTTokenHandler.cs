using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KAMLMSBackend.Authentication
{
    public class JWTTokenHandler
    {
        private IConfiguration config;
        public JWTTokenHandler(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateToken(string username, Guid userId)
        {
            var a =config.GetValue<string>("TOKEN_SECRET");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("TOKEN_SECRET")));
            var credientials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                                new Claim("Issuer",config.GetValue<string>("ISSUER")),
                                new Claim("Admin",config.GetValue<string>("AUDIENCE")),
                                new Claim(JwtRegisteredClaimNames.UniqueName,userId.ToString()),
                                new Claim(JwtRegisteredClaimNames.Name,username)
                                };

            var token = new JwtSecurityToken(issuer: config.GetValue<string>("ISSUER"),
                                            audience: config.GetValue<string>("AUDIENCE"),
                                            claims: claims,
                                            expires: DateTime.Now.AddMinutes(60),
                                            signingCredentials: credientials
                                            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
