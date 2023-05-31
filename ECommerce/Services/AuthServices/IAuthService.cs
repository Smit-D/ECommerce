using Services.Models;
using Services.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServices
{
    public interface IAuthService
    {
        Task<ApiResponse> AuthenticateUserAsync(AuthenticateRequest user);
    }
}
