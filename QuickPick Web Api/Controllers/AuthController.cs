using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuickPickWebApi.Core;
using QuickPickWebApi.Core.Models;
using QuickPickWebApi.Services.Authentication;
using QuickPickWebApi.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace QuickPick_Web_Api.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthServices AuthServices { get; }
        DatabaseContext DbContext { get; }

        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthServices authServices, IConfiguration config, DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            AuthServices = authServices;
            DbContext = context;
            _config = config;
        }
        private UnitOfWork<DatabaseContext> unitOfWork;
        /// <summary>
        /// UnitOfWork
        /// </summary>
        public UnitOfWork<DatabaseContext> UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork<DatabaseContext>(DbContext);
                }
                return unitOfWork;
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(SignupViewModel userForRegister)
        {
            userForRegister.EmailId = userForRegister.EmailId.ToLower();
            
            if (await AuthServices.UserExists(userForRegister.EmailId)|| await AuthServices.UserExists(userForRegister.ContactNo))
                return BadRequest("Username already exists");

 
            var userToCreate = _mapper.Map<Customer>(userForRegister);

            var createdUser = await AuthServices.Register(userToCreate, userForRegister.Password);

            var userToReturn = _mapper.Map<Customer>(createdUser);

            // return CreatedAtRoute("GetUser", new
            // {
            //     controller = "Users",
            //     id = createdUser.Email
            // }, createdUser);
            return Ok(new
            {
                id = createdUser.EmailId,
                createdUser
            });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var userFromRepo = await AuthServices.Login(username.ToLower(), password);

            if (userFromRepo == null)
                return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.EmailId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.EmailId)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<Customer>(userFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
        [HttpGet]
        public string Get()
        {
            return "Auth Api is working";
        }
    }
}