using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IItemPromocaoService
    {
        Task CadastrarItemPromocao(ItemPromocao itemPromocao);
        Task AtualizarItemPromocao(ItemPromocao itemPromocao);
        Task<IEnumerable<ItemPromocao>> ObterItemPromocaoPorPromocao(int promocaoId);
        Task<IEnumerable<ItemPromocao>> ObterItemPromocaoPorProduto(int produtoId);
        Task RemoverItemPromocao(int promocaoId);
    }
}
