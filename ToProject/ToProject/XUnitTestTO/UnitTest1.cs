using System;
using Xunit;

namespace XUnitTestTO
{
    public class UnitTest1
    {
        private readonly IUsuarioRepositorio _usuarioRepo;
        public UnitTest1(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
