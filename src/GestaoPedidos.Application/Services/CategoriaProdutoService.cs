using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoService(ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }

        public async Task CadastrarCategoriaProduto(CategoriaProduto categoriaProduto)
        {
            await _categoriaProdutoRepository.Cadastrar(categoriaProduto);
        }

        public async Task AtualizarCategoriaProduto(CategoriaProduto categoriaProduto)
        {
            await _categoriaProdutoRepository.Atualizar(categoriaProduto);
        }

        public Task<IEnumerable<CategoriaProduto>> ObterCategoriaProduto()
        {
            return _categoriaProdutoRepository.Obter();
        }

        public Task<CategoriaProduto?> ObterCategoriaProduto(int categoriaId)
        {
            return _categoriaProdutoRepository.Obter(categoriaId);
        }

        public async Task RemoverCategoriaProduto(int categoriaId)
        {
            await _categoriaProdutoRepository.Remover(categoriaId);
        }
    }
}
