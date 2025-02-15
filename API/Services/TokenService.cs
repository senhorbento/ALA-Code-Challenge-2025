using API.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService()
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Token._KEY_));
        }
        public string CreateToken(string user, string role)
        {
            List<Claim> claims =
            [
                new Claim(JwtRegisteredClaimNames.NameId, user),
                new Claim(ClaimTypes.Role, role)

            ];
            SigningCredentials creds = new(_key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(1440),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
