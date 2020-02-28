using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        IEnumerable<UsuarioDomain> ListarUsuarios();

        IEnumerable<UsuarioDomain> ListarPorId(int Id);

        void Cadastrar(UsuarioDomain UsuarioRecebido);

        void Atualizar(int Id, UsuarioDomain UsuarioAtualizado);

        void Deletar(int Id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
