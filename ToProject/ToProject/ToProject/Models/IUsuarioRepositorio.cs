using ToProject.Entityes;

namespace ToProject.Models
{
   public interface IUsuarioRepositorio
    {
        DTOUsuario Inserir_Usuario(Usuario user);
        DTOUsuario Login(Usuario user);
    }
}
