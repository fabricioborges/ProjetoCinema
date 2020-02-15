using Projeto_Cinema.API.Models;
using Projeto_Cinema.Application.Features.Users;
using Projeto_Cinema.Application.Features.Users.Commands;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Login
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        IUserAppService UserAppService;

        public LoginController(IUserAppService appService)
        {
            UserAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Authenticate(UserLoginCommand loginCommand)
        {
            var loginResponse = new LoginResponse { };
            LoginRequest loginrequest = new LoginRequest { };
            loginrequest.Username = loginCommand.Email;
            loginrequest.Password = loginCommand.Password;

            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage();
            bool isUsernamePasswordValid = false;

            if (loginCommand != null)
                isUsernamePasswordValid = UserAppService.GetUserByEmail(loginCommand);
            // if credentials are valid
            if (isUsernamePasswordValid)
            {
                string token = createToken(loginrequest.Username);
                //return the token
                return Ok<string>(token);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(loginResponse.responseMsg);
                return response;
            }
        }

        private string createToken(string username)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddDays(7);

            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
                        
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:9870/", audience: "http://localhost:3000",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
