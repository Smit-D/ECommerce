using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AuthServices;
using Services.Models;
using Services.Models.Request;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        #region Declaration
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAuthService _authenticateService;
        #endregion

        #region Authenticate Constructor
        public AuthenticateController(IHttpContextAccessor httpContext, IAuthService authenticateServices)
        {
            _httpContext = httpContext;
            _authenticateService = authenticateServices;
        }
        #endregion

        #region Authenticate User
        /// <summary>
        /// Check user authetication and return user and jwt token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        [HttpPost(template: "/authenticate")]
        public async Task<IActionResult> AuthenticateUserAsync([FromBody] AuthenticateRequest model)
        {
            if (ModelState.IsValid)
            {
                //check credeentials and return response containing user model and jwt token
                var response = await _authenticateService.AuthenticateUserAsync(model);
                if(response.Model != null)
                {
                    return Ok(response);
                }
                return NotFound(response);
            }
            else
            {
                throw new InvalidDataException("Model State is Invalid!");
            }
        }
        #endregion

        [Authorize(Roles = "Admin,User")]
        [HttpGet(template: "/test")]
        public IActionResult Test()
        {
            return Ok("Login succesful");
        }


        #region Logout
        /// <summary>
        /// Remove cookie from cookie and return ok response
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "/logout")]
        public ApiResponse Logout()
        {
            //Remove token from cookie 
            //_httpContext.HttpContext?.Response.Cookies.Delete("jwtToken");
           
            return new ApiResponse(statusCode: StatusCodes.Status200OK,"Logout Successful!");
        }
        #endregion
    }
}
