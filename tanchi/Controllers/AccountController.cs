using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tanchi.dal.Entities;
using tanchi.DTOs;

namespace tanchi.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public AccountController(
            UserManager<dal.Entities.User> userManager,
            SignInManager<User> signInManager,
            ILoggerFactory loggerFactory,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _mapper = mapper;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="LoginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                var token = await GetJwtSecurityToken(user);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else
            {
                ModelState.AddModelError("error", "Wrong user name or password");
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="RegisterViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            var NewUser = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(NewUser, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(NewUser, isPersistent: false);
                _logger.LogInformation(3, "User created a new account with password.");
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest();
        }


        private async Task<JwtSecurityToken> GetJwtSecurityToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            return new JwtSecurityToken(
                issuer: "localhost:62068",
                audience: "localhost:62068",
                claims: GetTokenClaims(user).Union(userClaims),
                expires: DateTime.UtcNow.AddMinutes(50),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsBetterThanYours")), SecurityAlgorithms.HmacSha256)
            );
        }

        private static IEnumerable<Claim> GetTokenClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };
        }


    }
}
