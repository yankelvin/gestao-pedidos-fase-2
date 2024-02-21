using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(Usuario usuario);
        Task AtualizarUsuario(Usuario usuario);
        Task<IEnumerable<Usuario>> ObterUsuario();
        Task<Usuario?> ObterUsuario(int usuarioId);
        Task RemoverUsuario(int usuarioId);
    }
}
