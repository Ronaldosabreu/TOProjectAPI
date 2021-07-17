using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TO.Entityes;

namespace TO.DTO
{
    public class DTO_Usuario
    {
        public string Mensagem { get; set; }
        public List<Usuario> Lista_Usuarios { get; set; }
    }
}
