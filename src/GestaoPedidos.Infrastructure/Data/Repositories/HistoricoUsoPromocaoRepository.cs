using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Entities.Promocoes;

namespace GestaoPedidos.Infrastructure.Data.Repositories
{
    public class HistoricoUsoPromocaoRepository : IHistoricoUsoPromocaoRepository
    {
        private readonly IMapper _mapper;
        private readonly PromocaoContext _promocaoContext;

        public HistoricoUsoPromocaoRepository(IMapper mapper, PromocaoContext promocaoContext)
        {
            _mapper = mapper;
            _promocaoContext = promocaoContext;
        }

        public async Task InserirUsoPromocao(HistoricoUsoPromocao historicoUsoPromocao)
        {
            var entity = _mapper.Map<HistoricoUsoPromocaoEntity>(historicoUsoPromocao);
            await _promocaoContext.HistoricosUsoPromocoes.AddAsync(entity);
            await _promocaoContext.SaveChangesAsync();
        }

        public Task<IEnumerable<HistoricoUsoPromocao>> ObterPorCliente(int clienteId)
        {
            var entities = _promocaoContext.HistoricosUsoPromocoes.Where(i => i.idCliente.Equals(clienteId));
            var historico = _mapper.Map<IEnumerable<HistoricoUsoPromocao>>(entities);
            return Task.FromResult(historico);
        }
    }
}
