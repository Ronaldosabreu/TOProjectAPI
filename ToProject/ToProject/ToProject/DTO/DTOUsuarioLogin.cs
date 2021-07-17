using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToProject.Entityes;

namespace ToProject.DTO
{
    public class DTOUsuarioLogin
    {

        public string mensagem { get; set; }

        public Guid Id { get; set; }
        public DateTime created { get; set; }
        public string token { get; set; }
        public DateTime modified { get; set; }
        public DateTime last_login { get; set; }
        public ICollection<Profiles> Profiles_User { get; set; }


    }
}
