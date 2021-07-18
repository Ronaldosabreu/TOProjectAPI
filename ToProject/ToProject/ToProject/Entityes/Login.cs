using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToProject.Entityes
{
    public class Login
    {
        [Required(ErrorMessage = "PREENCHA O EMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PREENCHA A SENHA")]
        public string Senha { get; set; }
    }
}
