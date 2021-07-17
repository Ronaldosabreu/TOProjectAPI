using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TO.Entityes;
using TO.Model;

namespace TO.api
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ListaUsuariosController : ControllerBase
    {
        //UsuarioModel _usuario = new UsuarioModel();

        private readonly Context _context;
        private readonly UsuarioModel _usu;
        public ListaUsuariosController(Context context, UsuarioModel usu)
        {
            _context = context;
            _usu = usu;
        }


        //private readonly UsuarioModel _usuario;
        //public ListaUsuariosController(UsuarioModel user)
        //{
        //    _usuario = user;
        //}


        [HttpGet("Todos_Usuarios")]
        public IActionResult Todos_Usuarios()
        {
           

            var usuarios = _usu.Todos_Usuarios(_context);
            if (usuarios.Mensagem == "OK")
            {
                return Ok(usuarios);
            }
            else
            {
                return BadRequest(usuarios);
            }

        }


        [HttpPost]
        [Route("Inserir_Usuario")]
        public IActionResult Inserir_Usuario([FromBody] Usuario usuario)
        {
            UsuarioModel _usuario = new UsuarioModel();

            var usuarios = _usuario.Inserir_Usuario(usuario, _context);

            if (usuarios.Mensagem == "INSERIDO COM SUCESSO")
            {
               
               return Ok(usuarios);
            }
            else
            {
               
                return BadRequest(usuarios);
            }
        }

    }
}
