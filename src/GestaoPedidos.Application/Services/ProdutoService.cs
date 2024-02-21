using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task CadastrarProduto(Produto produto)
        {
            await _produtoRepository.Cadastrar(produto);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        public Task<IEnumerable<Produto>> ObterProduto()
        {
            return _produtoRepository.Obter();
        }

        public Task<Produto?> ObterProduto(int produtoId)
        {
            return _produtoRepository.Obter(produtoId);
        }

        public Task<IEnumerable<Produto>> ObterProdutoPorCategoria(int categoriaId)
        {
            return _produtoRepository.ObterPorCategoria(categoriaId);
        }

        public async Task RemoverProduto(int produtoId)
        {
            await _produtoRepository.Remover(produtoId);
        }
    }
}
