using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Obter();
        Task<Usuario?> Obter(int usuarioId);
        Task Cadastrar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(int usuarioId);
    }
}
