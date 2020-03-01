using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

         [Required(ErrorMessage = "Informe a senha")]
         [DataType(DataType.Password)]
         [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no minimo 3 caracteres ")]
         public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}
