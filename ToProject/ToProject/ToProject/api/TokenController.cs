using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToProject.Models;

namespace ToProject.api
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepositorio _iusuario;
        public TokenController(IConfiguration configuration, IUsuarioRepositorio usuario)
        {
            _configuration = configuration;
            _iusuario = usuario;
        }



        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResquestToken([FromBody] Usuarios resquest)
        {
            _iusuario.Login(resquest)

            if (resquest.Em == "Mac" && resquest.Senha == "numsey")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, resquest.Nome)
                    //new Claim(ClaimTypes.Role, "Admin"),
                };

                //recebe uma instancia da classe symmetricsecuritykeu
                //armazena a chave criptografada usada na criação do token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe obj do tipo SigninCredentials contendo a chave de criptografia e algoritimo de segurança
                //de geracao de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //gerando a audiencia do token, e definindo tempo para este token
                var token = new JwtSecurityToken(
                    issuer: "APIGps",
                    audience: "APIGps",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credencial Inálida...");
        }
    }
}
