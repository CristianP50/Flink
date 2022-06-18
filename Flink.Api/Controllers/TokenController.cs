﻿using Flink.Appication.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Flink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TokenController : ControllerBase
    {

        [HttpPost]
        public IActionResult GetToken(UserLoginRequest loginRequest)
        {
            var IsValideUser = ValidateUser(loginRequest);
            if (!IsValideUser)
                return Unauthorized();

            var token = GenerateToken(loginRequest.UserName);
            return Ok( new {token});
        }


        private bool ValidateUser(UserLoginRequest LoginRequest)
        {
            if (LoginRequest.UserName == "admin" && LoginRequest.Password == "abc123")
                return true;
            return false;
        }

        private string GenerateToken(string userName)
        {
            //header
            var privatekey = "asdasdadasdasdasdgjdkwalsk";
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privatekey));
            var singingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(singingCredentials);


            //Payload
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userName),
                new Claim(ClaimTypes.Role,"Administrador"),

            };

            var payload = new JwtPayload
                (
                "https://localhost:7238", //Issuer (Quien hizo la petición)
                "https://localhost:7238", //audience verificar si es quuien me lo haya enviado
                claims,
                DateTime.Now,// Fecha de generacion del token
                DateTime.Now.AddMinutes(5)//Fecha de expiración del token
                );


            var token = new JwtSecurityToken(header, payload);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
