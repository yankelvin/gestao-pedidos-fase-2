using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Entities.Produtos;

namespace GestaoPedidos.Infrastructure.Data.Repositories
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        private readonly IMapper _mapper;
        private readonly ProdutoContext _produtoContext;

        public CategoriaProdutoRepository(IMapper mapper, ProdutoContext produtoContext)
        {
            _mapper = mapper;
            _produtoContext = produtoContext;
        }

        public async Task Cadastrar(CategoriaProduto categoria)
        {
            var entity = _mapper.Map<CategoriaProdutoEntity>(categoria);
            await _produtoContext.Categorias.AddAsync(entity);
            await _produtoContext.SaveChangesAsync();

        }

        public async Task Atualizar(CategoriaProduto categoria)
        {
            var entity = _mapper.Map<CategoriaProdutoEntity>(categoria);
            _produtoContext.Categorias.Update(entity);
            await _produtoContext.SaveChangesAsync();

        }

        public Task<IEnumerable<CategoriaProduto>> Obter()
        {
            var entities = _produtoContext.Categorias.ToList();
            var categorias = _mapper.Map<IEnumerable<CategoriaProduto>>(entities);
            return Task.FromResult(categorias);
        }

        public Task<CategoriaProduto?> Obter(int categoriaId)
        {
            var entity = _produtoContext.Categorias.FirstOrDefault(p => p.Id.Equals(categoriaId));
            if (entity == null)
                throw new KeyNotFoundException($"Identificador da categoria inexistente. {categoriaId}");

            var categoria = _mapper.Map<CategoriaProduto>(entity);
            return Task.FromResult(categoria);
        }

        public async Task Remover(int categoriaId)
        {
            var entity = _produtoContext.Categorias.FirstOrDefault(p => p.Id.Equals(categoriaId));

            if (entity != null)
            {
                _produtoContext.Categorias.Remove(entity);
                await _produtoContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador da categoria inexistente. {categoriaId}");
        }
    }
}
