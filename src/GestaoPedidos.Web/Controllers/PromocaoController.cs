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
    [Route("api/promocoes")]
    public class PromocaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPromocaoService _promocaoService;

        public PromocaoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Obter promocao por id
        /// </summary>
        /// <param name="promocaoId" example="432">Identificador da promocao para buscar</param>
        /// <response code="200">OK, Promocao consultada</response>
        /// <response code="404">Promocao nao encontrada</response>
        [HttpGet("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<PromocaoDTO> Get(int promocaoId)
        {
            var promocao = await _promocaoService.ObterPromocao(promocaoId);
            return _mapper.Map<PromocaoDTO>(promocao);
        }

        /// <summary>
        /// Obter promocoes
        /// </summary>
        /// <response code="200">OK, Promocao consultada</response>
        /// <response code="404">Promocao nao encontrada</response>
        [HttpGet]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<PromocaoDTO>> Get()
        {
            var promocoes = await _promocaoService.ObterPromocao();
            return _mapper.Map<IEnumerable<PromocaoDTO>>(promocoes);
        }

        /// <summary>
        /// Cadastrar promocao
        /// </summary>
        /// <response code="200">OK, Promocao cadastrada</response>
        /// <response code="500">Erro ao cadastrar promocao</response>
        [HttpPost]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] PromocaoDTO promocaoDTO)
        {
            var promocao = _mapper.Map<Promocao>(promocaoDTO);
            await _promocaoService.CadastrarPromocao(promocao);
        }

        /// <summary>
        /// Atualizar promocao
        /// </summary>
        /// <response code="200">OK, Promocao atualizada</response>
        /// <response code="500">Erro ao atualizar promocao</response>
        [HttpPut]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] PromocaoDTO promocaoDTO)
        {
            var promocao = _mapper.Map<Promocao>(promocaoDTO);
            await _promocaoService.AtualizarPromocao(promocao);
        }

        /// <summary>
        /// Remover promocao
        /// </summary>
        /// <response code="200">OK, Promocao removida</response>
        /// <response code="500">Erro ao remover promocao</response>
        [HttpDelete("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int promocaoId)
        {
            await _promocaoService.RemoverPromocao(promocaoId);
        }
    }
}
