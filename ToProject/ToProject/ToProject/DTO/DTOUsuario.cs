using System;
using System.Collections.Generic;
using ToProject.Entityes;

namespace ToProject.Models
{
    public class DTOUsuario
    {


        public string mensagem { get; set; }

        public Guid Id { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public DateTime last_login { get; set; }
        public ICollection<Profiles> Profiles_User { get; set; }

        

    }
}
