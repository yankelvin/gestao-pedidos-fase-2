using AutoMapper;
using GestaoPedidos.Application.DTOs.Pedido;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Enums;
using GestaoPedidos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace GestaoPedidos.Web.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/pedido")]
public class PedidoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPedidoService _pedidoService;

    public PedidoController(IMapper mapper, IPedidoService pedidoService)
    {
        _mapper = mapper;
        _pedidoService = pedidoService;
    }

    /// <summary>
    /// Cadastro do pedido
    /// </summary>
    /// <param name="dto"></param>
    /// <response code="200">Pedido cadastrado</response>
    [HttpPost]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] CadastroPedidoDto dto)
    {
        try
        {
            var id = await _pedidoService.CadastrarPedido(dto.IdCliente, dto.Produtos);
            return Ok(JsonConvert.SerializeObject(new { mensagem = "Pedido Cadastrado", id_pedido = id }));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Obtém os dados do pedido por id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Dados do cliente encontrado</response>
    /// <response code="404">Cliente não encontrado</response>
    [HttpGet("{id:int:required}")]
    [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<PedidoDTO> Get(int id)
    {
        var pedido = _pedidoService.ObterPedido(id);

        if (pedido is null)
            return NotFound("Pedido não encontrado");

        return _mapper.Map<PedidoDTO>(pedido);
    }

    /// <summary>
    /// Obtém os todos os pedidos ou lista os pedidos do cliente
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Lista de pedidos</response>
    [HttpGet("get-all")]
    [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
    public IEnumerable<PedidoDTO> GetAll([FromQuery] int? idCliente, Status? statusPedido)
    {
        var listaPedidos = _pedidoService.ObterTodosPedidos(idCliente, statusPedido);

        return _mapper.Map<IEnumerable<PedidoDTO>>(listaPedidos);
    }

    /// <summary>
    /// Delete pedido por id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Pedido deletado</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpDelete("{id:int:required}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var sucesso = _pedidoService.DeletarPedido(id);

        if (sucesso)
            return Ok("Pedido deletado com sucesso!");

        return NotFound("Pedido não encontrado");
    }

    /// <summary>
    /// Update dos dados pedid
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Pedido atualizado</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpPut]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult Put([FromBody] AtualizarPedidoDTO dto)
    {
        var pedido = _mapper.Map<Pedido>(dto);
        var sucesso = _pedidoService.AtualizarPedido(pedido);

        if (sucesso)
            return Ok("Pedido atualizado");

        return NotFound("Pedido não encontrado");
    }

    /// <summary>
    /// Próxima etapa do pedido
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Pedido atualizado</response>
    /// <response code="404">Pedido não encontrado</response>
    [HttpPost("next-step/{idPedido:int:required}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult NextStep(int idPedido)
    {
        var novoStatus = _pedidoService.ProximaEtapaPedido(idPedido);

        return Ok($"Novo status do pedido {novoStatus}");
    }

    [HttpGet("stress")]
    public ActionResult Stress()
    {
        Random rand = new Random();
        List<Thread> threads = new List<Thread>();
        
        while (true)
        {
            threads.Add( new Thread( new ThreadStart(() =>
            {
                long num = 0;
                while(true)
                {
                    num += rand.Next(100, 1000);
                    if (num > 1000000) { num = 0; }
                }
            }) ) );
        }
    }
}