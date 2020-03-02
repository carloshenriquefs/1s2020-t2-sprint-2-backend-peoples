using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositorio
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source = LAPTOP-N251D43S\\TEW_SQLEXPRESS; initial catalog=M_Peoples;integrated security = true";
        //private string stringConexao = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tipoUsuarios = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM TipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                        IdTipoUsuario = Convert.ToInt32(rdr[0]),
                        IdUsuario = Convert.ToInt32(rdr[1]),
                        Tipo = rdr["Tipo"].ToString(),
                        };
                        tipoUsuarios.Add(tipoUsuario);
                    }
                }
            }
            return tipoUsuarios;
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdTipoUsuario, IdUsuario FROM TipoUsuario WHERE IdTipoUsuario = @ID, IdUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Tipo = rdr["Tipo"].ToString()

                        };

                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE TipoUsuario SET IdTipoUsuario = @IdTipoUsuario, IdUsuario = @IdUsuario WHERE IdTipoUsuario = @ID ";

                using(SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TipoUsuario", tipoUsuarioAtualizado.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Usuario", tipoUsuarioAtualizado.IdUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @ID";

                using(SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
