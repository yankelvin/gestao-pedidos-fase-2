using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories
{
    public interface IItemPromocaoRepository
    {
        Task<IEnumerable<ItemPromocao>> ObterPorPromocao(int promocaoId);
        Task<IEnumerable<ItemPromocao>> ObterPorProduto(int produtoId);
        Task Cadastrar(ItemPromocao promocao);
        Task Atualizar(ItemPromocao promocao);
        Task Remover(int promocaoId);
    }
}
