using DemoAPI.Contract.Request;
using DemoAPI.Contract.Response;
using DemoAPI.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private  IUsers userService;
        

        public AccountController(IUsers user, IConfiguration config)
        {
            userService = user;
            _config = config;
        }

        private IConfiguration _config { get; }


        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(SignInModel model)
        {
            if (model != null)
            {
                var user = userService.SignIn(model);
                //var apiResponse = new ApiResponse();
                if (user == null)
                {
                    string res = "Invalid user";
                    //not found Failure 
                    //apiResponse.Ok = false;
                    //apiResponse.Status = 404;
                    //apiResponse.Message = "Invalid Login credentials !";
                    return Ok(res);
                }
                else
                {
                    //success Login
                    string token = GenerateJSONWebToken();
                    //apiResponse.Ok = true;
                    //apiResponse.Status = 200;
                    //apiResponse.Message = "Login success !";
                    //apiResponse.Data = user;
                    //apiResponse.Token = token; // we will send token later by JWT(JSON Web Token) call
                    return Ok(token);
                }

            }
            else
            {
                return BadRequest() ;
            }
        
        }
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignIUp(SignUpModel model)
        {
            if (model != null)
            {
                var user = userService.SignUp(model);
                var apiResponse = new ApiResponse();
                
                    apiResponse.Ok = true;
                    apiResponse.Status = 200;
                    apiResponse.Message = "User Created successfully !";
                    apiResponse.Data = user;
                    return Ok(apiResponse);

            }
            else
            {
                return BadRequest();
            }


        }
        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
