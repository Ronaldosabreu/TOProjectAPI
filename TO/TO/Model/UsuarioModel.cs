using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TO.DTO;
using TO.Entityes;

namespace TO.Model
{
    public class UsuarioModel
    {

        public DTO_Usuario_Profile Todos_Usuarios(Context _context)
        {
            DTO_Usuario_Profile _dto_usuario = new DTO_Usuario_Profile();

            var blogs = _context.Usuarios.FromSqlRaw("SELECT * FROM usuario u join profile p on p.Usuario_Id = u.Id").ToList();

            //_dto_usuario.Usuario = _context.Usuarios.Find();
            //if (_dto_usuario.Usuario.Id = "")
            //{
            //    _dto_usuario.Mensagem = "Não há usuários cadastrado";
            //}
            //else
            //{
            //    _dto_usuario.Mensagem = "OK";
            //}
            return _dto_usuario;
        }

        public DTO_Usuario_Profile Inserir_Usuario(Usuario usuario, Context _context)
        {

            DTO_Usuario_Profile _dto_usuario_profile = new DTO_Usuario_Profile();

            DateTime data = DateTime.Now;
            usuario.Created = data;
            try
            {
                var q = (from c in _context.Usuarios where c.Email == usuario.Email select c).ToList();
                if (q.Count > 0)
                {
                    _dto_usuario_profile.Mensagem = "EMAIL JÁ CADASTRADO";
                    return _dto_usuario_profile;
                }
                else
                {
                    _context.Add(usuario);
                    Guid id = usuario.Id;
                    foreach (var item in usuario.Profiles)
                    {
                        item.Usuario_Id = id;
                        _context.Add(item);

                    }
                    _context.SaveChanges();
                    _dto_usuario_profile.Usuario = _context.Usuarios.Find(id);
                    _dto_usuario_profile.Mensagem = "INSERIDO COM SUCESSO";
                }
            }
            catch (Exception ex)
            {
                _dto_usuario_profile.Mensagem = "Erro ao Gravar usuário";
            }
            return _dto_usuario_profile;
        }

    }
}
