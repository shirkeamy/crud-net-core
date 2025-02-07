using crud_net_core.DataServices;
using crud_net_core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_net_core.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginServices loginServices;
        public LoginController() { 
            loginServices = new LoginServices();
        }

        [HttpPost("validate-user")]
        public IActionResult ValidateUser([FromBody]LoginBody loginBody)
        {
            LoginMaster userDetail = loginServices.GetLoginDetails(loginBody);
            
            if (userDetail.UserName == null)
            {
                return BadRequest(new
                {
                    isLoggedIn = false,
                    errorMessage = "User details are not found in database",
                    payLoad = "",
                });
            }

            return Ok(new
            {
                isLoggedIn = true,
                errorMessage = "",
                payLoad = userDetail,
            });
        }

    }
}
