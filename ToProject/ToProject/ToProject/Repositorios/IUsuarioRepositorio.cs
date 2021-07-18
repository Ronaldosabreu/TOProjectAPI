using ToProject.DTO;
using ToProject.Entityes;

namespace ToProject.Models
{
   public interface IUsuarioRepositorio
    {
        DTOUsuario Inserir_Usuario(Usuario user);
        DTOUsuarioLogin Login(Login user);
    }
}
