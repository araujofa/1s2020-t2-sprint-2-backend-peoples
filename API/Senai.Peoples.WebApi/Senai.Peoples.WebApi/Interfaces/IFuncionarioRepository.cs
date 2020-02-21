using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {

        List<FuncionarioDomain> Listar();

        List<FuncionarioDomain> ListarporId(int Id);

        List<FuncionarioDomain> ListarPorNome(string Buscar);

        void Cadastrar(FuncionarioDomain funcionarioRecebido);

        void Atualizar(int Id, FuncionarioDomain funcionarioAtualizado);

        void Deletar(int Id);

    }
}
