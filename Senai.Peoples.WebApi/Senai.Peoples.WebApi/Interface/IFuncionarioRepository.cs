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

        FuncionarioDomain BuscarPorId(int id);

        void Cadastrar(FuncionarioDomain funcionario);

        FuncionarioDomain BuscarNomeFuncionario(string nome);

        void Atualizar(int id, FuncionarioDomain funcionarioAtualizado);

        void Deletar(int id);

        List<FuncionarioDomain> ListarNomeCompleto();

        List<FuncionarioDomain> ListarOrdenado(string ordem);

        FuncionarioDomain ObrigatorioNome(string nome);
        //void AtualizarIdUrl(int id, FuncionarioDomain funcionario);
        //void AtualizarIdCorpo(int id, FuncionarioDomain funcionario);


    }
}
