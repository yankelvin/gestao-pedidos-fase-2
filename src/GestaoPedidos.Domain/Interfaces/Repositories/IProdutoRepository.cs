using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterPorCategoria(int categoriaId);
        Task<IEnumerable<Produto>> Obter();
        Task<Produto?> Obter(int produtoId);
        Task Cadastrar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int produtoId);
    }
}
