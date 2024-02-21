using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _usuarioRepository.Cadastrar(usuario);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            await _usuarioRepository.Atualizar(usuario);
        }

        public Task<IEnumerable<Usuario>> ObterUsuario()
        {
            return _usuarioRepository.Obter();
        }

        public Task<Usuario?> ObterUsuario(int usuarioId)
        {
            return _usuarioRepository.Obter(usuarioId);
        }

        public async Task RemoverUsuario(int usuarioId)
        {
            await _usuarioRepository.Remover(usuarioId);
        }
    }
}
