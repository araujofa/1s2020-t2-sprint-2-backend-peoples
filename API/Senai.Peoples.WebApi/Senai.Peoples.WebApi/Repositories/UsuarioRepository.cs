using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV1101\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public void Atualizar(int Id, UsuarioDomain UsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain UsuarioRecebido)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioDomain> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string query = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuarios WHERE Email = @Email AND Senha = @Senha";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while (rdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);

                            usuario.Email = rdr["Email"].ToString();

                            usuario.Senha = rdr["Senha"].ToString();

                            usuario.IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]);
                        }

                        return usuario;
                    }
                }

                return null;
            }
        }

        public IEnumerable<UsuarioDomain> ListarUsuarios()
        {

            List<UsuarioDomain> lista = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "SELECT IdUsuario, Nome, Email, TipoUsuario.IdTipoUsuario, TipoUsuario.Titulo FROM Usuarios INNER JOIN TipoUsuario ON Usuarios.IdTipoUsuario = TipoUsuario.IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while (rdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(rdr[0]);

                            usuario.Nome = rdr["Nome"].ToString();

                            usuario.Email = rdr["Email"].ToString();

                            usuario.IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]);

                            TipoUsuarioDomain TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr[3]),
                                Titulo = rdr["Titulo"].ToString()
                            };

                            lista.Add(usuario);
                        }
                        return lista;

                    }
                    return null;
                }

            }
        }
    }   
}
