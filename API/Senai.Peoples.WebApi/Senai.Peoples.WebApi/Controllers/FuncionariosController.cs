using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpGet("{Id}")]
        public IEnumerable<FuncionarioDomain> ListarPorId(int Id)
        {
            
            return _funcionarioRepository.ListarporId(Id);
              
        }

        [HttpGet("Buscar/{Busca}")]
        public IEnumerable<FuncionarioDomain> ListarBusca(string Busca)
        {
            return _funcionarioRepository.ListarPorNome(Busca);
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, FuncionarioDomain funcionarioAtualizado)
        {
            if(funcionarioAtualizado != null)
            {
               _funcionarioRepository.Atualizar(Id, funcionarioAtualizado);
               return StatusCode(200, "Funcionario atualizado");
            }
            return StatusCode(400, "Funcionario nao atualizado");
        }

        
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioCadastrado)
        {
            if(funcionarioCadastrado != null)
            {

                _funcionarioRepository.Cadastrar(funcionarioCadastrado);
                return StatusCode(201, "Funcionario cadastrado");

            }
            return StatusCode(400, "Funcionario nao cadastrado");
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _funcionarioRepository.Deletar(Id);
            return StatusCode(200);
        }
    }
}