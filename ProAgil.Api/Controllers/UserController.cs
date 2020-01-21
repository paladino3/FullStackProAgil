using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProAgil.Api.Dtos;
using ProAgil.Domain.Identity;

namespace ProAgil.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser () {
            return Ok(new UserDto());
        }

        [HttpPost("Registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar(UserDto userDto)
         {
            try 
            {
                var user = _mapper.Map<User>(userDto);

                var result = await _userManager.CreateAsync(user, userDto.Password);

                var userToReturn = _mapper.Map<UserDto>(user);

                if(result.Succeeded)
                {
                    return Created("GetUser", userToReturn);
                }
                return BadRequest(result.Errors);
            }   
            catch (System.Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou.. " + ex.Message);
            }
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login (UserLoginDto UserLogin) {
           try
           {
               var user = await _userManager.FindByNameAsync(UserLogin.UserName);

               var result = await _signInManager.CheckPasswordSignInAsync(user, UserLogin.Password, false);//verificar se o usuario tem o mesmo password


               if(result.Succeeded)
               {
                   var appUser = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.NormalizedUserName == UserLogin.UserName.ToUpper());

                        var userToReturn = _mapper.Map<UserLoginDto>(appUser);

                        return Ok(new {
                            token = GenerateJWBToken(appUser).Result,
                            user = userToReturn
                        });
               }

               return Unauthorized();
           }
           catch (System.Exception ex)
           {
               
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou.. " + ex.Message);
           }
        }
    //metodo mais importante de validacao JWT
        private async Task<String> GenerateJWBToken(User user)
        {
            var claims = new List<Claim>//claim e uma autorizacoes
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            //roles
            var papeis = await _userManager.GetRolesAsync(user);// buscando qual o papel deste usaruio, adm? dir? usr?

            foreach (var papelUsuario in papeis)
            {
                claims.Add(new Claim(ClaimTypes.Role, papelUsuario));
            }
            /*{
                Id: 1,
                username: username,
                roles: [admin, gerente, redator, usuario]    
            }*/

            //key
            var chave = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(_config.GetSection("AppSettings: Token").Value)); //descriptografar
            
            
            //creds
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha512Signature); // metodo de criptografia

            var tokenDecriptor = new  SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credencial
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}