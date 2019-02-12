using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TokenApp;
using WebApi.BLL.Providers.Contracts;
using WebApi.DAL.Models.DomainModel.Auth;
using WebApi.ViewModel;

namespace WebApi.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        public AccountController( IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, Password = model.Password };
                // добавляем пользователя
                await _userProvider.CreateUserAsync(user);;
            }
            return Ok();
        }
        [HttpPost("/token")]
        public async Task Token([FromBody] User user)
        {

            if (!GetIdentity(user.Email, user.Password))
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                userName = user.Email
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private bool GetIdentity(string username, string password)
        {
            var user = _userProvider.GetUserAsync(username, password);
            if (user != null)
            {
                return true;
            }

            // если пользователя не найдено
            return false;
        }
    }
}