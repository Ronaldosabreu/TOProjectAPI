using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToProject.Entityes;

namespace ToProject.DTO
{
    public class DTPTestUsuario
    {
        
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }


        public List<DTOProfile> Profiles_User { get; set; }
    }
}
