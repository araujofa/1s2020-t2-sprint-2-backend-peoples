using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=DEV1101\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public void Atualizar(int Id, FuncionarioDomain funcionarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@Id", Id);

                 
                    rdr = cmd.ExecuteReader();

                }
            }
        }

        public void Cadastrar(FuncionarioDomain funcionarioRecebido)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO Funcionarios(Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @Data)";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioRecebido.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioRecebido.Sobrenome);
                    cmd.Parameters.AddWithValue("@Data", funcionarioRecebido.DataNascimento);
                    
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    rdr = cmd.ExecuteReader();

                }
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> lista = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLista = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLista, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {

                        FuncionarioDomain funcionarios = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = DateTime.Parse(rdr["DataNascimento"].ToString())
                        };

                        lista.Add(funcionarios);
                    }
                    return lista;
                }

            }

        }

        public List<FuncionarioDomain> ListarporId(int Id)
        {
            List<FuncionarioDomain> lista = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLista = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE IdFuncionario = @Id";

                con.Open();


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLista, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        FuncionarioDomain funcionarios = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = DateTime.Parse(rdr["DataNascimento"].ToString())
                        };

                        lista.Add(funcionarios);
                    }
                    return lista;
                }

            }
        }

        public List<FuncionarioDomain> ListarPorNome(string Buscar)
        {
            List<FuncionarioDomain> lista = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLista = $"SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome LIKE '%{Buscar}%' ORDER BY Nome DESC";

                con.Open();


                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLista, con))
                {
                    
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        FuncionarioDomain funcionarios = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = DateTime.Parse(rdr["DataNascimento"].ToString())
                        };

                        lista.Add(funcionarios);
                    }
                    return lista;
                }

            }
        }
    }
}
