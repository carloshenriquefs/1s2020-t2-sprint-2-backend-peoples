using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface IUsuarioRepository
    {
        void Cadastrar(UsuarioDomain usuario);

        List<UsuarioDomain> Listar();

        UsuarioDomain BuscarPorId(int id);

        void Atualizar(int id, UsuarioDomain usuarioAtualizado);

        void Deletar(int id);


        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
