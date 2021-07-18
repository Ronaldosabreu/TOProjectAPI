using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToProject.DTO;
using ToProject.Entityes;
using ToProject.Models;
using ToProject.UTIL;

namespace ToProject.api
{

    [ApiController]
    [Route("api/[controller]")]
    public class Usuarios : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuario_inserir_Repo;
        private readonly IConfiguration _configuration;
        public Usuarios(IUsuarioRepositorio usuarioRepo, IConfiguration configuration)
        {
            _configuration = configuration;
            _usuario_inserir_Repo = usuarioRepo;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login usuario)
        {
                if (usuario.Email == null)
            {
                return BadRequest(new { mensagem = "EMAIL OBRIGATORIO" });
            }

            DTOUsuarioLogin dto_usuarios = _usuario_inserir_Repo.Login(usuario);


            if (dto_usuarios.mensagem == "OK")
            {

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email)
                };

                //recebe uma instancia da classe symmetricsecuritykeu
                //armazena a chave criptografada usada na criação do token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe obj do tipo SigninCredentials contendo a chave de criptografia e algoritimo de segurança
                //de geracao de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //gerando a audiencia do token, e definindo tempo para este token
                var token = new JwtSecurityToken(
                    issuer: "TOBrasil",
                    audience: "TOBrasil",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                    );

                dto_usuarios.token = new JwtSecurityTokenHandler().WriteToken(token).ToString();

                return Ok(JsonConvert.SerializeObject(dto_usuarios));
            }
            else
            {
                return Unauthorized(new { mensagem = dto_usuarios.mensagem });
            }
        }


        [HttpPost]
        [Route("Inserir_Usuario")]
        public IActionResult Inserir_Usuario([FromBody] Usuario usuario)
        {
            HashSenha hash = new HashSenha();

            usuario.Senha = hash.Codifica(usuario.Senha);

            DTOUsuario usuarios = _usuario_inserir_Repo.Inserir_Usuario(usuario);
            if (usuarios.mensagem == "INSERIDO COM SUCESSO")
            {
                return Ok(JsonConvert.SerializeObject(usuarios));
            }
            else
            {
                return BadRequest(new { mensagem = usuarios.mensagem });
            }
        }


    }
}
