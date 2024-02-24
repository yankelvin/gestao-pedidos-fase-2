using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Entities.Pagamentos;

namespace GestaoPedidos.Infrastructure.Data.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly IMapper _mapper;
        private readonly PagamentoContext _pagamentoContext;

        public PagamentoRepository(IMapper mapper, PagamentoContext pagamentoContext)
        {
            _mapper = mapper;
            _pagamentoContext = pagamentoContext;
        }

        public async Task Cadastrar(Pagamento pagamento)
        {
            var entity = _mapper.Map<PagamentoEntity>(pagamento);
            await _pagamentoContext.Pagamentos.AddAsync(entity);
            await _pagamentoContext.SaveChangesAsync();
        }

        public async Task Atualizar(Pagamento pagamento)
        {
            var entity = _mapper.Map<PagamentoEntity>(pagamento);
            _pagamentoContext.Pagamentos.Update(entity);
            await _pagamentoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Pagamento>> Obter()
        {
            var entities = _pagamentoContext.Pagamentos.ToList();
            var pagamentos = _mapper.Map<IEnumerable<Pagamento>>(entities);
            return Task.FromResult(pagamentos);
        }

        public Task<Pagamento?> Obter(int pagamentoId)
        {
            var entity = _pagamentoContext.Pagamentos.FirstOrDefault(p => p.Id.Equals(pagamentoId));
            if (entity == null)
                throw new KeyNotFoundException($"Identificador do Pagamento inexistente. {pagamentoId}");

            var pagamento = _mapper.Map<Pagamento>(entity);
            return Task.FromResult(pagamento);
        }

        public async Task Remover(int pagamentoId)
        {
            var entity = _pagamentoContext.Pagamentos.FirstOrDefault(p => p.Id.Equals(pagamentoId));

            if (entity != null)
            {
                _pagamentoContext.Pagamentos.Remove(entity);
                await _pagamentoContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador do Pagamento inexistente. {pagamentoId}");
        }

        public Task<IEnumerable<Pagamento>> ObterPorPedido(int pedidoId)
        {
            var entities = _pagamentoContext.Pagamentos.Where(i => i.IdPedido.Equals(pedidoId));
            var pagamentos = _mapper.Map<IEnumerable<Pagamento>>(entities);
            return Task.FromResult(pagamentos);
        }
    }
}
