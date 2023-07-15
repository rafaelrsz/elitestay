using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Shared;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using EliteStay.Domain.BookingContext.Services;

namespace EliteStay.Infra.BookingContext.Services
{
  public class TokenService : ITokenService
  {
    public string GenerateToken(User user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Settings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(
          new Claim[]
          {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.permission.ToString())
          }),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials =
          new SigningCredentials(new SymmetricSecurityKey(key),
          SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}