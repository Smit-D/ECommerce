using Common.AppSettings;
using Common.Helper;
using Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.Models;
using Services.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServices
{
    public class AuthService : IAuthService
    {
        #region Declaration
        private readonly SecretKeys _secretKeys;
        private readonly JwtSettings _jwtSettings;
        private readonly ECommerceDBContext _context;
        #endregion

        #region Auth Constructor
        public AuthService(IOptions<JwtSettings> jwtoptions,IOptions<SecretKeys> keyoptions, ECommerceDBContext context)
        {
            _jwtSettings = jwtoptions.Value;
            _secretKeys = keyoptions.Value;
            _context = context;
        }
        #endregion

        #region Authenticate User and Generate Token
        /// <summary>
        /// Get User details and generate token on authentication success
        /// </summary>
        /// <param name="authenticateRequest"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequest authenticateRequest)
        {
            
            var getUser = await _context.TblUsers
                            .Include(user => user.Role)
                            .FirstOrDefaultAsync(user => user.Email == authenticateRequest.Email.Trim().ToLower() && user.IsActive == true);//Fetch user if exists
            
            if (getUser == null)
            {
                return new ApiResponse(StatusCodes.Status404NotFound, "User Not Found!");
            }

            if (getUser.Password == EncryptPasswordHelper.Encrypt(authenticateRequest.Password.Trim(), _secretKeys.EncryptionKey ?? "AS1ZX5EDFC212"))
            {
                
                UserDto userDto = new(getUser);//Map TblUser to UserDto
                userDto.Token = JwtTokenHelper.GenerateToken(_jwtSettings, getUser); //Generate Token
                return new ApiResponse(StatusCodes.Status200OK, "Login Successful!", userDto);
          
            }
           
            return new ApiResponse(StatusCodes.Status400BadRequest, "Invalid Credentials"); //return incorrext credentials as message if password in wrong
        }
        #endregion
    }
}
