using AutoMapper;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Services;
using GestaoPedidos.Application.DTOs.Pagamento;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GestaoPedidos.Web.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/pagamentos")]
    public class PagamentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IMapper mapper, IPagamentoService pagamentoService)
        {
            _mapper = mapper;
            _pagamentoService = pagamentoService;
        }

        /// <summary>
        /// Obter pagamentos
        /// </summary>
        /// <response code="200">OK, Pagamentos consultados</response>
        /// <response code="404">Pagamentos nao encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagamentoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<PagamentoDTO>> Get()
        {
            var pagamentos = await _pagamentoService.ObterPagamento();
            return _mapper.Map<IEnumerable<PagamentoDTO>>(pagamentos);
        }

        /// <summary>
        /// Obter pagamento por id
        /// </summary>
        /// <param name="pagamentoId" example="54322345-5432-2345-5432-543223455432">Identificador do pagamento para buscar</param>
        /// <response code="200">OK, Pagamento consultado</response>
        /// <response code="404">Pagamento nao encontrado</response>
        [HttpGet("{pagamentoId:int:required}")]
        [ProducesResponseType(typeof(PagamentoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<PagamentoDTO> Get(int pagamentoId)
        {
            var pagamento = await _pagamentoService.ObterPagamento(pagamentoId);
            return _mapper.Map<PagamentoDTO>(pagamento);
        }

        /// <summary>
        /// Obter pagamentos por id do pedido
        /// </summary>
        /// <param name="Id" example="432">Identificador do pedido para buscar</param>
        /// <response code="200">OK, Pagamentos por pedido consultado</response>
        /// <response code="404">Pagamentos nao encontrados para pedido</response>
        [HttpGet("pedido/{pedidoId:int:required}")]
        [ProducesResponseType(typeof(PagamentoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<PagamentoDTO>> GetPor(int pedidoId)
        {
            var pagamentos = await _pagamentoService.ObterPagamentoPorPedido(pedidoId);
            return _mapper.Map<IEnumerable<PagamentoDTO>>(pagamentos);
        }

        /// <summary>
        /// Cadastrar pagamento
        /// </summary>
        /// <response code="200">OK, pagamento cadastrada</response>
        /// <response code="500">Erro ao cadastrar pagamento</response>
        [HttpPost]
        [ProducesResponseType(typeof(PagamentoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] PagamentoDTO pagamentoDTO)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            await _pagamentoService.CadastrarPagamento(pagamento);
        }

        /// <summary>
        /// Atualizar pagamento
        /// </summary>
        /// <response code="200">OK, Pagamento atualizado</response>
        /// <response code="500">Erro ao atualizar pagamento</response>
        [HttpPut]
        [ProducesResponseType(typeof(PagamentoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] PagamentoDTO pagamentoDTO)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoDTO);
            await _pagamentoService.AtualizarPagamento(pagamento);
        }

        /// <summary>
        /// Remover pagamento
        /// </summary>
        /// <response code="200">OK, Pagamento removido</response>
        /// <response code="500">Erro ao remover pagamento</response>
        [HttpDelete("{pagamentoId:int:required}")]
        [ProducesResponseType(typeof(PagamentoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int pagamentoId)
        {
            await _pagamentoService.RemoverPagamento(pagamentoId);
        }
    }
}
