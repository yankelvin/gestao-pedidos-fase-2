using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class ItemPromocaoService : IItemPromocaoService
    {
        private readonly IItemPromocaoRepository _itemPromocaoRepository;

        public ItemPromocaoService(IItemPromocaoRepository itemPromocaoRepository)
        {
            _itemPromocaoRepository = itemPromocaoRepository;
        }

        public async Task CadastrarItemPromocao(ItemPromocao itemPromocao)
        {
            await _itemPromocaoRepository.Cadastrar(itemPromocao);
        }

        public async Task AtualizarItemPromocao(ItemPromocao itemPromocao)
        {
            await _itemPromocaoRepository.Atualizar(itemPromocao);
        }

        public Task<IEnumerable<ItemPromocao>> ObterItemPromocaoPorProduto(int produtoId)
        {
            return _itemPromocaoRepository.ObterPorProduto(produtoId);
        }

        public Task<IEnumerable<ItemPromocao>> ObterItemPromocaoPorPromocao(int promocaoId)
        {
            return _itemPromocaoRepository.ObterPorPromocao(promocaoId);
        }

        public async Task RemoverItemPromocao(int promocaoId)
        {
            await _itemPromocaoRepository.Remover(promocaoId);
        }
    }
}
