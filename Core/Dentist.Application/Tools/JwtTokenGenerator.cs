using Dentist.Application.Dtos;
using Dentist.Application.Features.Mediator.Results.AuthorizationResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(LoginQueryResult result)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(result.Role))
                claims.Add(new Claim(ClaimTypes.Role, result.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(result.UserName))
                claims.Add(new Claim("Username", result.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(JwtTokenDefaults.ValidIssuer, JwtTokenDefaults.ValidAudience, claims, DateTime.UtcNow, expireDate, signingCredentials);
            JwtSecurityTokenHandler tokenHandler = new();
            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate, result.Id.ToString(), result.UserName);
           // return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate, result.Id.ToString(), result.UserName, result.DoctorId, result.PatientId);

        }
    }
}
