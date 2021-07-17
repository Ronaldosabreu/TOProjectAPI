using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToProject.Entityes;
using ToProject.Models;
using ToProject.UTIL;

namespace TesteUnitario
{
    [TestClass]
    public class UnitTest1
    {

        private readonly IUsuarioRepositorio _usuarioRepo;
        public UnitTest1(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }


        [TestMethod]
        public void Criar()
        {

            HashSenha hash = new HashSenha();

            Usuario dto = new Usuario();
            DTOUsuario dtoS = new DTOUsuario();

            dto.Email = "b";
            dto.Senha = "b";
            dto.Nome = "b";

            dto.Senha = hash.Codifica(dto.Senha);

            Assert.AreEqual(dtoS.mensagem = "INSERIDO COM SUCESSO", _usuarioRepo.Inserir_Usuario(dto));
            

        }

        [TestMethod]
        public void Login_retorno()
        {
           
            Usuario dto = new Usuario();

            dto.Email = "b";
            dto.Senha = "b";
            Assert.IsNotNull(_usuarioRepo.Login(dto));

        }
    }
}
