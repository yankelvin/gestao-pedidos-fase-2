using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories
{
    public interface ICategoriaProdutoRepository
    {
        Task<IEnumerable<CategoriaProduto>> Obter();
        Task<CategoriaProduto?> Obter(int categoriaId);
        Task Cadastrar(CategoriaProduto categoria);
        Task Atualizar(CategoriaProduto categoria);
        Task Remover(int categoriaId);
    }
}
