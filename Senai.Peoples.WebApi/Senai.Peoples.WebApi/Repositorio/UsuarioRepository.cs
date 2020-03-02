using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source = LAPTOP-N251D43S\\TEW_SQLEXPRESS; initial catalog=M_Peoples;integrated security = true";
        //private string stringConexao = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";

        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuario (Email, Senha) VALUES (@Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert))
                {
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };

                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }

        public void Atualizar(int id, UsuarioDomain usuarioAtualizado)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Usuarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimentoF = @DataNascimentoF WHERE IdUsuario = @ID";

                using(SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Email", usuarioAtualizado.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuarioAtualizado.Senha);
                    cmd.Parameters.AddWithValue("@Permissao", usuarioAtualizado.Permissao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectPorID = "SELECT IdUsuario, Email, Senha FROM Usuario WHERE IdUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectPorID, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IDUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };

                        return usuario;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM Usuario WHERE IdUsuario = @ID";

                using(SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelect = "SELECT IdUsuario, Email, Senha, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while(rdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);

                            usuario.Email = rdr["Email"].ToString();

                            usuario.Senha = rdr["Senha"].ToString();

                            usuario.Permissao = rdr["Permissao"].ToString();
                        }
                        return usuario;       
                    }
                }
                return null;
            }
        }


    }
}
