using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositorio
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string StringConexao = "Data Source = DEV501\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";
        //private string StringConexao = "Data Source = LAPTOP-N251D43S\\TEW_SQLEXPRESS; initial catalog=M_Peoples;integrated security = true ";

        //LISTAR TODOS OS FUNCIONARIOS
        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT * FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimentoF = rdr["DataNascimentoF"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }


        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimentoF) VALUES (@Nome, @Sobrenome, @DataNascimentoF)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimentoF", funcionario.DataNascimentoF);

                    con.Open();

                    cmd.ExecuteNonQuery();





                }

            }
        }

        //BUSCAR PELO ID - FUNCIONARIO
        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectPorID = "SELECT IdFuncionarios, Nome, Sobrenome, DataNascimentoF FROM Funcionarios WHERE IdFuncionarios = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectPorID, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IDFuncionarios"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimentoF = rdr["DataNascimentoF"].ToString()

                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeleta = "DELETE FROM Funcionarios WHERE IdFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeleta, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimentoF = @DataNascimentoF WHERE IdFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimentoF", funcionario.DataNascimentoF);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarIdCorpo(int id, FuncionarioDomain funcionarioA)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizar = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimentoF = @DataNascimentoF WHERE IdFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionarioA.IdFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionarioA.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioA.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimentoF", funcionarioA.DataNascimentoF);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void NomeObrigatorio(string nome, FuncionarioDomain funcionarioNome)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryNome = "SELECT Nome FROM Funcionarios";

                using (SqlCommand cmd = new SqlCommand(queryNome, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioNome.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public FuncionarioDomain ObrigatorioNome(string nome)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarNomeFuncionario(string nome)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryNomeBuscar = "SELECT Nome FROM Funcionarios WHERE Nome = @Nome";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryNomeBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionarioNome = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IDFuncionarios"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimentoF = rdr["DataNascimentoF"].ToString()
                        };

                        return funcionarioNome;
                    }
                    return null;
                }
            }

        }

        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimentoF = @DataNascimentoF WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionarioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimentoF", funcionarioAtualizado.DataNascimentoF);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarNomeCompleto()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

           using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdFuncionario, CONCAT (Nome, ' ', Sobrenome), DataNascimentoF FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr[1].ToString(),
                            Sobrenome = rdr[2].ToString(),
                            DataNascimentoF = rdr["DataNascimentoF"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public List<FuncionarioDomain> ListarOrdenado(string ordem)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimentoF FROM Funcionarios ORDER BY Nome {ordem}";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimentoF = rdr["DataNascimentoF"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
    }
}
