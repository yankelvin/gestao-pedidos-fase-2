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
    [Route("api/item-promocoes")]
    public class ItemPromocaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemPromocaoService _itemPromocaoService;

        public ItemPromocaoController(IMapper mapper, IItemPromocaoService itemPromocaoService)
        {
            _mapper = mapper;
            _itemPromocaoService = itemPromocaoService;
        }

        /// <summary>
        /// Obter item promocao por id da promocao
        /// </summary>
        /// <param name="promocaoId" example="432">Identificador da item promocao para buscar</param>
        /// <response code="200">OK, Item Promocao consultada</response>
        /// <response code="404">Item Promocao nao encontrada</response>
        [HttpGet("promocao/{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ItemPromocaoDTO>> GetPorPromocao(int promocaoId)
        {
            var itensPromocoes = await _itemPromocaoService.ObterItemPromocaoPorPromocao(promocaoId);
            return _mapper.Map<IEnumerable<ItemPromocaoDTO>>(itensPromocoes);
        }

        /// <summary>
        /// Obter item promocao por id do produto
        /// </summary>
        /// <param name="produtoId" example="432">Identificador da item promocao para buscar</param>
        /// <response code="200">OK, Item Promocao consultada</response>
        /// <response code="404">Item Promocao nao encontrada</response>
        [HttpGet("produto/{produtoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ItemPromocaoDTO>> GetPorProduto(int produtoId)
        {
            var itensPromocao = await _itemPromocaoService.ObterItemPromocaoPorProduto(produtoId);
            return _mapper.Map<IEnumerable<ItemPromocaoDTO>>(itensPromocao);
        }


        /// <summary>
        /// Cadastrar item promocao
        /// </summary>
        /// <response code="200">OK, Item Promocao cadastrada</response>
        /// <response code="500">Erro ao cadastrar item promocao</response>
        [HttpPost]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] ItemPromocaoDTO promocaoDTO)
        {
            var promocao = _mapper.Map<ItemPromocao>(promocaoDTO);
            await _itemPromocaoService.CadastrarItemPromocao(promocao);
        }

        /// <summary>
        /// Atualizar item promocao
        /// </summary>
        /// <response code="200">OK, item Promocao atualizado</response>
        /// <response code="500">Erro ao atualizar item promocao</response>
        [HttpPut]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] ItemPromocaoDTO promocaoDTO)
        {
            var itemPromocao = _mapper.Map<ItemPromocao>(promocaoDTO);
            await _itemPromocaoService.AtualizarItemPromocao(itemPromocao);
        }

        /// <summary>
        /// Remover item promocao
        /// </summary>
        /// <response code="200">OK, Item Promocao removido</response>
        /// <response code="500">Erro ao remover item promocao</response>
        [HttpDelete("{promocaoId:int:required}")]
        [ProducesResponseType(typeof(PromocaoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int promocaoId)
        {
            await _itemPromocaoService.RemoverItemPromocao(promocaoId);
        }
    }
}
