using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface ICategoriaProdutoService
    {
        Task CadastrarCategoriaProduto(CategoriaProduto categoriaProduto);
        Task AtualizarCategoriaProduto(CategoriaProduto categoriaProduto);
        Task<IEnumerable<CategoriaProduto>> ObterCategoriaProduto();
        Task<CategoriaProduto?> ObterCategoriaProduto(int categoriaId);
        Task RemoverCategoriaProduto(int categoriaId);
    }
}
