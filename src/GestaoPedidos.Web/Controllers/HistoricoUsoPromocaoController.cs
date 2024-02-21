using AutoMapper;
using GestaoPedidos.Application.DTOs.Promocao;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GestaoPedidos.Web.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/historico-uso-promocao")]
    public class HistoricoUsoPromocaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHistoricoUsoPromocaoService _historicoUsoPromocaoService;

        public HistoricoUsoPromocaoController(IMapper mapper, IHistoricoUsoPromocaoService promocaoService)
        {
            _mapper = mapper;
            _historicoUsoPromocaoService = promocaoService;
        }

        /// <summary>
        /// Cadastrar historico uso promocao
        /// </summary>
        /// <response code="200">OK, Historico Uso Promocao cadastrado</response>
        /// <response code="500">Erro ao cadastrar Historico Uso Promocao</response>
        [HttpPost]
        [ProducesResponseType(typeof(HistoricoUsoPromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] HistoricoUsoPromocaoDTO historicoUsoPromocaoDTO)
        {
            var historicoUsoPromocao = _mapper.Map<HistoricoUsoPromocao>(historicoUsoPromocaoDTO);
            await _historicoUsoPromocaoService.CadastrarHistoricoUsoPromocao(historicoUsoPromocao);
        }

        /// <summary>
        /// Obter historico uso promocao por id do cliente
        /// </summary>
        /// <param name="clienteId" example="432">Identificador do cliente para buscar</param>
        /// <response code="200">OK, Historico consultado</response>
        /// <response code="404">Historico nao encontrado</response>
        [HttpGet("{clienteId:int:required}")]
        [ProducesResponseType(typeof(HistoricoUsoPromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<HistoricoUsoPromocaoDTO>> Get(int clienteId)
        {
            var historico = await _historicoUsoPromocaoService.ObterHistoricoUsoPromocao(clienteId);
            return _mapper.Map<IEnumerable<HistoricoUsoPromocaoDTO>>(historico);
        }
    }
}
