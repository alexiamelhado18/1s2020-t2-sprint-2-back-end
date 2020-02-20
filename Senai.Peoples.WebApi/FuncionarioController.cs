using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        public FuncionarioController()
        {

            _FuncionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListarFuncionarios()
        {
            return _FuncionarioRepository.ListarFuncionario();
        }

        [HttpGet("{id}")]
        public IActionResult FunBuscaId(int id)
        {
          FuncionarioDomain funcionario =  _FuncionarioRepository.BuscarFunId(id);
           
            if (funcionario != null)
            {
            return Ok("Funcionario encontrado");

            }return NotFound("Funcionário não encontrado");
        }

        [HttpPost]
        public IActionResult CadastrarFun(FuncionarioDomain funcionario)
        {
             _FuncionarioRepository.CadastrarFun(funcionario.NomeFun, funcionario.SobrenomeFun);

            return Created(201);
        }

   }
}