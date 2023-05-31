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
        private readonly SecretKeys _secretKeys;
        private readonly JwtSettings _jwtSettings;
        private readonly ECommerceDBContext _context;
        public AuthService(IOptions<JwtSettings> jwtoptions,IOptions<SecretKeys> keyoptions, ECommerceDBContext context)
        {
            _jwtSettings = jwtoptions.Value;
            _secretKeys = keyoptions.Value;
            _context = context;
        }
        public async Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequest authenticateRequest)
        {
            var getUser = await _context.TblUsers.Include(user => user.Role).FirstOrDefaultAsync(user => user.Email == authenticateRequest.Email && user.IsActive == true);
            if (getUser == null)
            {
                return new ApiResponse(StatusCodes.Status404NotFound, "User Not Found!");
            }
            if (getUser.Password == EncryptPasswordHelper.Encrypt(authenticateRequest.Password, _secretKeys.EncryptionKey ?? "AS1ZX5EDFC212"))
            {
                UserDto userDto = new(getUser);
                userDto.Token = JwtTokenHelper.GenerateToken(_jwtSettings, getUser);
                return new ApiResponse(StatusCodes.Status200OK, "Login Successful!", userDto);
            }
            return new ApiResponse(StatusCodes.Status400BadRequest, "Invalid Credentials");
        }
    }
}
