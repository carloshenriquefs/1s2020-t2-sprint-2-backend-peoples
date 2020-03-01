using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "Nome do Funcionario, Obrigatório!")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Data de Nascimento do funcionario: ")]
        [DataType(DataType.Date)]
        public string DataNascimentoF { get; set; }
        public FuncionarioDomain Funcionario { get; set; }
    }
}
