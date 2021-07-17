using System;
using System.Linq;
using ToProject.Entityes;
using ToProject.UTIL;

namespace ToProject.Models
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        
        private readonly Context _context;
        public UsuarioRepositorio(Context context)
        {
            _context = context;
        }


        public DTOUsuario Login(Usuario usuario)
        {
            Usuario dto = new Usuario();
            DTOUsuario retorno_dto = new DTOUsuario();
            HashSenha hash = new HashSenha();

            _context.Profiles.ToList();
            var login = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);


            if (login != null)
            {
                if (hash.Compara(usuario.Senha, login.Senha))
                {
                    retorno_dto = new DTOUsuario()
                    {
                        Id = login.Id,
                        created = login.Created,
                        modified = login.Modified,
                        last_login = login.Last_login,
                        Profiles_User = login.Profiles_User
                    };

                    retorno_dto.mensagem = "OK";
                    return retorno_dto;
                }
                else
                {

                    retorno_dto = new DTOUsuario()
                    {
                        mensagem = "usuario e/ou Senha incorretos"
                    };
    
                    return retorno_dto;
                }
            }
            else
            {
                retorno_dto = new DTOUsuario()
                {
                    mensagem = "Usuário Incorreto"
                };
            
                return retorno_dto;
            }
        }

        public DTOUsuario Inserir_Usuario(Usuario usuario)
        {
            DTOUsuario _dto_usuario_profile = new DTOUsuario();
            DateTime data = DateTime.Now;
            usuario.Created = data;
            usuario.Last_login = data;
            try
            {
                var q = (from c in _context.Usuarios where c.Email == usuario.Email select c).ToList();
                if (q.Count > 0)
                {


                    _dto_usuario_profile = new DTOUsuario()
                    {
                        mensagem = "Usuário Incorreto"
                    };

                    return _dto_usuario_profile;
                }
                else
                {
                    _context.Add(usuario);
                    Guid id = usuario.Id;
                    foreach (var item in usuario.Profiles_User)
                    {
                        item.Usuario_Id = id;
                        _context.Add(item);

                    }
                    _context.SaveChanges();
                    var retorno = _context.Usuarios.Find(id);

                    _dto_usuario_profile = new DTOUsuario()
                    {
                        Id = retorno.Id,
                        created = retorno.Created,
                        modified = retorno.Modified,
                        last_login = retorno.Last_login,
                        Profiles_User = retorno.Profiles_User
                    };

                    _dto_usuario_profile.mensagem = "INSERIDO COM SUCESSO";
                    return _dto_usuario_profile;
                }
            }
            catch (Exception ex)
            {

                _dto_usuario_profile = new DTOUsuario()
                {
                    mensagem = "Erro ao Gravar usuário"
                };
                
            }
            return _dto_usuario_profile;
        }

    }
}
