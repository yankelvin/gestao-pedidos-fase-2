using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task CadastrarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task<IEnumerable<Produto>> ObterProduto();
        Task<Produto?> ObterProduto(int produtoId);
        Task<IEnumerable<Produto>> ObterProdutoPorCategoria(int categoriaId);
        Task RemoverProduto(int produtoId);
    }
}
