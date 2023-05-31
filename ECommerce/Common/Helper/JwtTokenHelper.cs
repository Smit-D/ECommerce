using Common.AppSettings;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class JwtTokenHelper
    {
        #region Enum for User Roles
        private enum UserRoles
        {
            User = 1,
            Admin = 2,
        }
        #endregion

        #region Generate JWT Token
        //Generate JWT Token using jwtsettings and user model and set claims as needed
        public static string GenerateToken(JwtSettings jwtSettings, TblUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            //Adding Claims
            var claims = new ClaimsIdentity(new Claim[]
              {
                new Claim(ClaimTypes.Name,user.FirstName.ToString()),
                new Claim(ClaimTypes.UserData,user.UserId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.FirstName + " "+ user.LastName),
                new Claim(ClaimTypes.Role, Enum.GetName(typeof(UserRoles),value: user.RoleId)),
            });
            //parameters descriptors
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.TokenExpireInMins),//Can be in Days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience,
                IssuedAt = DateTime.UtcNow,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);// return generated token
        }
        #endregion

        #region Validate Token
        public static ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                //get appsettings values 
                // var jwtSettings = JObject.Parse(File.ReadAllText("appsettings.json"))["JwtSettings"];
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,// Validate the token's signature
                    //ValidAudience = jwtSettings["Audience"].ToString(),
                    //ValidIssuer = jwtSettings["Issuer"].ToString(),
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"].ToString())), // Set the secret key used to sign the token
                };

                // Create a token handler
                var tokenHandler = new JwtSecurityTokenHandler();

                // Validate the token and get principle claims
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validateToken);

                if (claimsPrincipal != null)
                {
                    // Token is valid
                    return claimsPrincipal;
                }
                else
                {
                    // Token is not valid
                    return null;
                }
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return null;
            }
        }
        #endregion
    }
}
