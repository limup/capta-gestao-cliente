using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using captaApi.Model;
using captaApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace captaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _repository;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<TbCliente>> Post(TbCliente cliente)
        {
            try
            {
                _logger.LogInformation("Executado o método de cadastro de cliente");

                // var validaCliente = await _repository.Cliente(cliente.Id);
                // if (validaCliente != null)
                //     return BadRequest("Cliente Já existe");


                _repository.AddCliente(cliente);

                return await _repository.SaveChangesAsync()
                    ? Ok("Cliente Cadastrado com sucesso")
                    : BadRequest("Erro ao cadastrar cliente");
            }
            catch (System.Exception ex)     
            {
                _logger.LogError(string.Format("Método Post: {0}", cliente), ex);
                return BadRequest("Erro ao cadastrar cliente");
            }
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<TbCliente>> Get()
        {
                try
                {
                    _logger.LogInformation("Executado o método de consulta em lote");

                    var clientes = await _repository.Clientes();

                    return clientes.Any()
                        ? Ok(clientes)
                        : NoContent();
                        }

                catch (System.Exception ex)
                {
                    _logger.LogError(string.Format("Método Consulta"), ex);
                    return BadRequest("Erro ao Consultar cliente");
                }
        }

        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<TbCliente>> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Executado o método de busca de cliente por id");

                var cliente = await _repository.Cliente(id);

                return cliente != null
                    ? Ok(cliente)
                    : NotFound("Cliente não encontrado");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(string.Format("Método Consulta por ID: {0}", id), ex);
                return BadRequest("Erro ao Consultar cliente");
            }
            
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<TbCliente>> Put(TbCliente cliente)
        {
            
            try
            {
                _logger.LogInformation("Executado o método de atualizaçao");

                var validaCliente = await _repository.Cliente(cliente.Id);
                
                if (validaCliente == null)
                    return NotFound("Cliente não encontrado");

                    _repository.PutCliente(cliente);
                // _repository.PutCliente(new TbCliente(){
                //     Cpf = cliente.Cpf, 
                //     Nome = cliente.Nome, 
                //     Sexo = cliente.Sexo,
                //     TbDominios = {
                //         new TbDominio(){
                //             Situacao = cliente.TbDominios.FirstOrDefault().Situacao,
                //             Tipo = cliente.TbDominios.FirstOrDefault().Tipo,
                //         }
                //     }
                // });

                return await _repository.SaveChangesAsync()
                    ? Ok("Cliente atualizado com sucesso")
                    : BadRequest("Erro ao atualizar cliente");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(string.Format("Método Atualiza : {0}", cliente), ex);
                return BadRequest("Erro ao Atualizar cliente");
            }
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult<TbCliente>> DeleteById(int id)
        {
            try
                {
                    _logger.LogInformation("Executado o método de exclusão de cliente por id");

                    _repository.DelCliente(id);

                    return await _repository.SaveChangesAsync()
                        ? Ok("Cliente excluido com sucesso")
                        : BadRequest("Erro ao excluir cliente");
                }
            catch (System.Exception ex)
            {
                _logger.LogError(string.Format("Método exclusão por ID : {0}", id), ex);
                return BadRequest("Erro ao excluir cliente");
            }
        }
    }
}