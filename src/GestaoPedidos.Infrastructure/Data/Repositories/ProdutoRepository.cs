using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Entities.Produtos;

namespace GestaoPedidos.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMapper _mapper;
        private readonly ProdutoContext _produtoContext;

        public ProdutoRepository(IMapper mapper, ProdutoContext produtoContext)
        {
            _mapper = mapper;
            _produtoContext = produtoContext;
        }

        public async Task Cadastrar(Produto produto)
        {
            var entity = _mapper.Map<ProdutoEntity>(produto);
            await _produtoContext.Produtos.AddAsync(entity);
            await _produtoContext.SaveChangesAsync();
        }

        public async Task Atualizar(Produto produto)
        {
            var entity = _mapper.Map<ProdutoEntity>(produto);
            _produtoContext.Produtos.Update(entity);
            await _produtoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Produto>> Obter()
        {
            var entities = _produtoContext.Produtos.ToList();
            var produtos = _mapper.Map<IEnumerable<Produto>>(entities);
            return Task.FromResult(produtos);
        }

        public Task<Produto?> Obter(int produtoId)
        {
            var entity = _produtoContext.Produtos.FirstOrDefault(p => p.Id.Equals(produtoId));
            if (entity == null)
                throw new KeyNotFoundException($"Identificador do Produto inexistente. {produtoId}");

            var produto = _mapper.Map<Produto>(entity);
            return Task.FromResult(produto);
        }

        public async Task Remover(int produtoId)
        {
            var entity = _produtoContext.Produtos.FirstOrDefault(p => p.Id.Equals(produtoId));

            if (entity != null)
            {
                _produtoContext.Produtos.Remove(entity);
                await _produtoContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador do Produto inexistente. {produtoId}");
        }

        public Task<IEnumerable<Produto>> ObterPorCategoria(int categoriaId)
        {
            var entities = _produtoContext.Produtos.Where(i => i.IdCategoria.Equals(categoriaId));
            var produtos = _mapper.Map<IEnumerable<Produto>>(entities);
            return Task.FromResult(produtos);
        }
    }
}
