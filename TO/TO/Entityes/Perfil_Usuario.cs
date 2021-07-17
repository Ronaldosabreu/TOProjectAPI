using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO.Entityes
{
    public class Perfil_Usuario
    {
        public int Id { get; set; }
        public Guid Usuario_Id { get; set; }
        public string Nivel { get; set; }

        public Usuario Usuario { get; set; }

    }
}
