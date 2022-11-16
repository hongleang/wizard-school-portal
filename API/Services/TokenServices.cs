using Microsoft.IdentityModel.Tokens;
using SchoolPortalAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolPortalAPI.Services
{
    public class TokenService : ITokenServices
    {
        // encrypt and decrypt electronic key -- remain on the server
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            // Encoding.UTF8 : encode the byte password
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(/*User user*/)
        {
            /*var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);*/
            return "";
        }

    }
}
