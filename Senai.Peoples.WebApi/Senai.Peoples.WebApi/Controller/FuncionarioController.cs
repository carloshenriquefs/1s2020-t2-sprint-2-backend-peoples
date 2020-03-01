using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using Senai.Peoples.WebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain funcionarioNovo)
        {
            _funcionarioRepository.Cadastrar(funcionarioNovo);

            return StatusCode(201);
        }

        [HttpGet("Buscar/{nome}")]
        public IActionResult BuscarNomeFuncionario(string nome)
        {
            FuncionarioDomain nomeBuscado = _funcionarioRepository.BuscarNomeFuncionario(nome);

            if(nomeBuscado == null)
            {
                return NotFound("Nome não encontrado!");
            }
            return Ok($"{nomeBuscado.Nome} Nome Encontrado!");

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if(funcionarioBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado!");
            }
            return Ok(funcionarioBuscado);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _funcionarioRepository.Deletar(id);
            return Ok("Funcionário Deletado!");
        }

        [HttpGet("nomescompletos")]
        public IActionResult GetFullName()
        {
            return Ok(_funcionarioRepository.ListarNomeCompleto());
        }

        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetOrderBy(string ordem)
        {
            if(ordem != "ASC" && ordem != "DESC")
            {
                return BadRequest("Não é possivel ordenar da maneira solicitado");
            }
            return Ok(_funcionarioRepository.ListarOrdenado(ordem));
        }

        [HttpGet("buscar/{buscar}")]
        public IActionResult GetByName(string busca)
        {
            return Ok(_funcionarioRepository.BuscarNomeFuncionario(busca));
        }

        //[HttpPut("{id}")]
        //public IActionResult AtualizarIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        //{
        //    FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

         //   if(funcionarioBuscado == null)
         //   {
         //       return NotFound(new { mensagem = "Gênero não encontrado", erro = true });
         //   }

         //   try
         //   {
         //       _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);
         //
         //       return NoContent();
         //   }
         //   catch(Exception erro)
         //   {
         //       return BadRequest(erro);
         //   }
       // }

        //[HttpPut]
        //public IActionResult AtualizarIdCorpo(int id,FuncionarioDomain funcionario)
        //{
          //  FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionario.IdFuncionario);

            //if(funcionarioBuscado != null)
            //{
              //  try
                //{
                 //   _funcionarioRepository.AtualizarIdCorpo(id,funcionario);

                //    return NoContent();
                //}
                //catch(Exception erro)
                //{
                 //   return BadRequest(erro);
                //}
           // }
           // return NotFound(new { mensagem = "Gênero não encontrado", erro = true });
       // }

        //public IActionResult NomeObrigatorio(string nome)
        //{
           // FuncionarioDomain funcionarioNomeObrigatorio = _funcionarioRepository.ObrigatorioNome(nome);

         //       try
         //       {
         //       funcionarioNomeObrigatorio.;
         //       }
         //       catch (Exception)
         //       {
         //           return NotFound("Nome não inserido no campo!");

         //       }
            
         //   return Ok("Nome Inserido!");
        //}
    }
}
