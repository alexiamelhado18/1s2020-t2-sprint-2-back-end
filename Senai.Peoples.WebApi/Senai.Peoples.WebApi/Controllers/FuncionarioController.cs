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
           
            if (funcionario == null) { 
            return NotFound("Funcionário não encontrado");
            }
            
            return Ok(funcionario);

        }

        [HttpPost]
        public IActionResult CadastrarFun(FuncionarioDomain funcionario)
        {

            _FuncionarioRepository.CadastrarFun(funcionario);

            return StatusCode(201, new { menssagem = "Funcionario cadastrado" });
            
        }

        [HttpPut]
        
        public IActionResult BuscarporCorpo(FuncionarioDomain funcionarios)

        {

            FuncionarioDomain funcionario = _FuncionarioRepository.BuscarFunId(funcionarios.IdFun);

            if (funcionario == null)
            {
                return NotFound(new { erro = "Funcionário não encontrado, impossível de editá-lo." });
            }
            try
            {
              _FuncionarioRepository.AlterarInfoFunCorpo(funcionarios);

                return NoContent();
            }
            catch (System.Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult BuscarPorId(int id, FuncionarioDomain funcionarios)
        {
         FuncionarioDomain funcionario = _FuncionarioRepository.BuscarFunId(funcionarios.IdFun);

            if (funcionarios == null)
            {
                return NotFound(new { erro = "Funcionário não encontrado, impossível de editá-lo." });
            }
            try
            {
                _FuncionarioRepository.AlterarInfoFunId(id,funcionarios);
            }
            catch (System.Exception erro)
            {

                return NotFound(erro);
            }
            return Ok(funcionarios);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarFun(int id)
        {
            FuncionarioDomain funcionario = _FuncionarioRepository.BuscarFunId(id);

            if (funcionario != null)
            {
                _FuncionarioRepository.DeletarFun(id);

                return Ok("Funcionario excluído com sucesso.");
               
            }
            try
            {
                return NotFound("Impossível de exclui usuário.");
            }
            catch (System.Exception erro)
            {

                return NotFound(erro);
            }
        }


        [HttpGet("RetornarNome/{NomeFun}")]
        public IActionResult OrdenarporNome(string nomeFun)
        {
            return StatusCode(200, _FuncionarioRepository.RetornarNome(nomeFun));
            //return StatusCode(200, _funcionarioRepository.BuscarPorNome(nome));
        }

        [HttpGet("RetornarFunASC/{ordemnsASC}")]
        public IActionResult RetornarFunASC(string ordemnsASC)
        {
            if (ordemnsASC == "ASC")
            {
                return StatusCode(200, _FuncionarioRepository.RetornarFunASC());
            }
            else
            {
                return StatusCode(400);
            }
        }


      }
    }
