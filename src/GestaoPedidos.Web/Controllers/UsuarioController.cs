using AutoMapper;
using GestaoPedidos.Application.DTOs.Usuario;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GestaoPedidos.Web.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Obter usuarios
        /// </summary>
        /// <response code="200">OK, Usuarios consultados</response>
        /// <response code="404">Usuarios nao encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            var usuario = await _usuarioService.ObterUsuario();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuario);
        }


        /// <summary>
        /// Obter usuario por id
        /// </summary>
        /// <param name="usuarioId" example="54322345-5432-2345-5432-543223455432">Identificador do usuario para buscar</param>
        /// <response code="200">OK, Usuario consultado</response>
        /// <response code="404">Usuario nao encontrado</response>
        [HttpGet("{usuarioId:int:required}")]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task<UsuarioDTO> Get(int usuarioId)
        {
            var usuario = await _usuarioService.ObterUsuario(usuarioId);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        /// <summary>
        /// Cadastrar usuario
        /// </summary>
        /// <response code="200">OK, usuario cadastrado</response>
        /// <response code="500">Erro ao cadastrar usuario</response>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Post([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioService.CadastrarUsuario(usuario);
        }

        /// <summary>
        /// Atualizar usuario
        /// </summary>
        /// <response code="200">OK, Usuario atualizado</response>
        /// <response code="500">Erro ao atualizar usuario</response>
        [HttpPut]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Put([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioService.AtualizarUsuario(usuario);
        }

        /// <summary>
        /// Remover usuario
        /// </summary>
        /// <response code="200">OK, usuario removido</response>
        /// <response code="500">Erro ao remover usuario</response>
        [HttpDelete("{usuarioId:int:required}")]
        [ProducesResponseType(typeof(UsuarioDTO), Status200OK)]
        [ProducesResponseType(typeof(void), Status404NotFound)]
        public async Task Delete(int usuarioId)
        {
            await _usuarioService.RemoverUsuario(usuarioId);
        }
    }
}
