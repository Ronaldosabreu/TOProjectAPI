using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToProject.Entityes
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "PREENCHA O NOME")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "PREENCHA O EMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PREENCHA O SENHA")]
        public string Senha { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Last_login { get; set; }

        public ICollection<Profiles> Profiles_User { get; set; }
    }
}
