using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain BuscarPorId(int id);

        void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado);

        void Deletar(int id);


        //void AtualizarIdCorpo(int id, TipoUsuarioDomain tipoUsuario);

    }
}
