using Cards.Business.Entity.CardEntity;
using Cards.Business.Entity.UserEntity;
using Cards.Business.Service.DBAccess;
using Cards.Business.Service.IService;
using Cards.Business.Service.Service;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace Cards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _IUserService;
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _IUserService = new UserService();
            _configuration = configuration;
        }
   

        [Route("LoginUser")]
        [HttpPost]
        public async Task<ActionResult<LoginUserResponseBE>>  LoginUser(LoginUserBE userBE)
        {
            //Checking if the field are valid
          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                LoginUserResponseBE loginUserResponseBE = new LoginUserResponseBE();
                loginUserResponseBE = _IUserService.Userlogin(userBE);
                if (loginUserResponseBE.Success == true)
                {
                    createToken createToken = new createToken(_configuration);
                    
                    loginUserResponseBE.Token = createToken.GeneratetokenString(userBE,loginUserResponseBE.Role);
                    HttpContext.Session.SetString("UserID", loginUserResponseBE.UserID.ToString());
                    HttpContext.Session.SetString("ROLE", loginUserResponseBE.Role.ToString());

                }
                return loginUserResponseBE;

            }
            catch (Exception e)
            {
                //LogBC.EntryLog("LoginController",e.Message);
                //error for saving 
                return null;
            }

        }


    }
}
