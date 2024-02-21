using AutoMapper;
using GestaoPedidos.Application.DTOs.Cliente;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace GestaoPedidos.Web.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/cliente")]
public class ClienteController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IClienteService _clienteService;

    public ClienteController(IMapper mapper, IClienteService clienteService)
    {
        _mapper = mapper;
        _clienteService = clienteService;
    }

    /// <summary>
    /// Cadastro dos dados do cliente caso não esteja cadastrado
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Cliente cadastrado</response>
    /// <response code="400">Cliente já cadastrado</response>
    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] CadastroClienteDto dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);

        await _clienteService.CadastrarCliente(cliente);

        return Ok("Cliente Cadastrado");
    }

    /// <summary>
    /// Obtém os dados do cliente por CPF
    /// </summary>
    /// <param name="cpf"></param>
    /// <response code="200">Dados do cliente encontrado</response>
    /// <response code="404">Cliente não encontrado</response>
    [HttpGet("{cpf:int:required}")]
    [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<ClienteDTO> Get(string cpf)
    {
        var cliente = _clienteService.ObterCliente(cpf);

        if (cliente is null)
            return NotFound("Cliente não encontrado");

        return _mapper.Map<ClienteDTO>(cliente);
    }

    /// <summary>
    /// Delete do cliente por id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Cliente deletado</response>
    /// <response code="404">Cliente não encontrado</response>
    [HttpDelete("{id:int:required}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var sucesso = _clienteService.DeletarCliente(id);

        if (sucesso)
            return Ok("Cliente deletado com sucesso!");

        return NotFound("Cliente não encontrado");
    }

    /// <summary>
    /// Update dos dados cliente
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Cliente atualizado</response>
    /// <response code="404">Cliente não encontrado</response>
    [HttpPut]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] AtualizarClienteDTO dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);
        var sucesso = _clienteService.AtualizarCliente(cliente);

        if (sucesso)
            return Ok("Cliente atualizado");

        return NotFound("Cliente não encontrado");
    }
}