using Microsoft.AspNetCore.Mvc;
using ToProject.Entityes;
using ToProject.Models;
using ToProject.UTIL;

namespace ToProject.api
{

    [ApiController]
    [Route("api/[controller]")]
    public class Usuarios : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        public Usuarios(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet("Login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {

            DTOUsuario dto_usuarios = _usuarioRepo.Login(usuario);

            if (dto_usuarios.mensagem == "OK")
            {
                return Ok(dto_usuarios);
            }
            else
            {
                return Unauthorized(dto_usuarios);
            }
        }


        [HttpPost]
        [Route("Inserir_Usuario")]
        public IActionResult Inserir_Usuario([FromBody] Usuario usuario)
        {
            HashSenha hash = new HashSenha();

            usuario.Senha = hash.Codifica(usuario.Senha);

            DTOUsuario usuarios = _usuarioRepo.Inserir_Usuario(usuario);
            if (usuarios.mensagem == "INSERIDO COM SUCESSO")
            {
                return Ok(usuarios);
            }
            else
            {
                return BadRequest(usuarios.mensagem);
            }
        }


    }
}
