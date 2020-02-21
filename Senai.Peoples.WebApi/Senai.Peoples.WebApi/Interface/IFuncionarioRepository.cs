using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();
        void Cadastrar(FuncionarioDomain funcionario);

        FuncionarioDomain BuscarPorId(int id);

        void Deletar(int id);
        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        void AtualizarIdCorpo(int id, FuncionarioDomain funcionario);

    }
}
