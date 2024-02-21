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
    [Route("api/categoria-produtos")]
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaProdutoService _categoriaProdutoService;

        public CategoriaProdutoController(IMapper mapper, ICategoriaProdutoService categoriaProdutoService)
        {
            _mapper = mapper;
            _categoriaProdutoService = categoriaProdutoService;
        }

        /// <summary>
        /// Obter categorias produtos
        /// </summary>
        /// <response code="200">OK, Categorias consultadas</response>
        /// <response code="404">Categorias nao encontradas</response>
        [HttpGet]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<CategoriaProdutoDTO>> Get()
        {
            var categorias = await _categoriaProdutoService.ObterCategoriaProduto();
            return _mapper.Map<IEnumerable<CategoriaProdutoDTO>>(categorias);
        }

        /// <summary>
        /// Obter categoria produto por id
        /// </summary>
        /// <param name="categoriaId" example="54322345-5432-2345-5432-543223455432">Identificador da categoria para buscar</param>
        /// <response code="200">OK, Categoria contultada</response>
        /// <response code="404">Categoria nao encontrada</response>
        [HttpGet("{categoriaId:int:required}")]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<CategoriaProdutoDTO> Get(int categoriaId)
        {
            var categoria = await _categoriaProdutoService.ObterCategoriaProduto(categoriaId);
            return _mapper.Map<CategoriaProdutoDTO>(categoria);
        }

        /// <summary>
        /// Cadastrar categoria
        /// </summary>
        /// <response code="200">OK, categoria cadastrada</response>
        /// <response code="500">Erro ao cadastrar categoria</response>
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] CategoriaProdutoDTO categoriaDTO)
        {
            var categoria = _mapper.Map<CategoriaProduto>(categoriaDTO);
            await _categoriaProdutoService.CadastrarCategoriaProduto(categoria);
        }

        /// <summary>
        /// Atualizar categoria
        /// </summary>
        /// <response code="200">OK, Categoria atualizada</response>
        /// <response code="500">Erro ao atualizar categoria</response>
        [HttpPut]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] CategoriaProdutoDTO categoriaDTO)
        {
            var categoria = _mapper.Map<CategoriaProduto>(categoriaDTO);
            await _categoriaProdutoService.AtualizarCategoriaProduto(categoria);
        }

        /// <summary>
        /// Remover categoria
        /// </summary>
        /// <response code="200">OK, Categoria removida</response>
        /// <response code="500">Erro ao remover categoria</response>
        [HttpDelete("{categoriaId:int:required}")]
        [ProducesResponseType(typeof(CategoriaProdutoDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int categoriaId)
        {
            await _categoriaProdutoService.RemoverCategoriaProduto(categoriaId);
        }
    }
}
