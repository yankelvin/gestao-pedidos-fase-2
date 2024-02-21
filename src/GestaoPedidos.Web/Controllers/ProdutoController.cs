using AutoMapper;
using GestaoPedidos.Application.DTOs.Produto;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GestaoPedidos.Web.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public ProdutoController(IMapper mapper, IProdutoService produtoService)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        /// <summary>
        /// Obter produtos
        /// </summary>
        /// <response code="200">OK, Produtos consultados</response>
        /// <response code="404">Produtos nao encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ProdutoDTO>> Get()
        {
            var produtos = await _produtoService.ObterProduto();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        /// <summary>
        /// Obter produto por id
        /// </summary>
        /// <param name="produtoId" example="54322345-5432-2345-5432-543223455432">Identificador do produto para buscar</param>
        /// <response code="200">OK, Produto consultado</response>
        /// <response code="404">Produto nao encontrado</response>
        [HttpGet("{produtoId:int:required}")]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<ProdutoDTO> Get(int produtoId)
        {
            var produto = await _produtoService.ObterProduto(produtoId);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        /// <summary>
        /// Obter produtos por id da categoria
        /// </summary>
        /// <param name="Id" example="432">Identificador da categoria para buscar</param>
        /// <response code="200">OK, Produtos por categoria consultado</response>
        /// <response code="404">Produtos nao encontrados para categoria</response>
        [HttpGet("categoria/{categoriaId:int:required}")]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<ProdutoDTO>> GetPor(int categoriaId)
        {
            var produtos = await _produtoService.ObterProdutoPorCategoria(categoriaId);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        /// <summary>
        /// Cadastrar produto
        /// </summary>
        /// <response code="200">OK, produto cadastrada</response>
        /// <response code="500">Erro ao cadastrar produto</response>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoService.CadastrarProduto(produto);
        }

        /// <summary>
        /// Atualizar produto
        /// </summary>
        /// <response code="200">OK, Produto atualizado</response>
        /// <response code="500">Erro ao atualizar produto</response>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoService.AtualizarProduto(produto);
        }

        /// <summary>
        /// Remover produto
        /// </summary>
        /// <response code="200">OK, Produto removido</response>
        /// <response code="500">Erro ao remover produto</response>
        [HttpDelete("{produtoId:int:required}")]
        [ProducesResponseType(typeof(ProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int produtoId)
        {
            await _produtoService.RemoverProduto(produtoId);
        }
    }
}
