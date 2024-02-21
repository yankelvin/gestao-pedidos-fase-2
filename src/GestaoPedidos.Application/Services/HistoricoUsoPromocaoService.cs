using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class HistoricoUsoPromocaoService : IHistoricoUsoPromocaoService
    {
        private readonly IHistoricoUsoPromocaoRepository _historicoUsoPromocaoRepository;

        public HistoricoUsoPromocaoService(IHistoricoUsoPromocaoRepository historicoUsoPromocaoRepository)
        {
            _historicoUsoPromocaoRepository = historicoUsoPromocaoRepository;
        }

        public async Task CadastrarHistoricoUsoPromocao(HistoricoUsoPromocao historicoUsoPromocao)
        {
            await _historicoUsoPromocaoRepository.InserirUsoPromocao(historicoUsoPromocao);
        }

        public Task<IEnumerable<HistoricoUsoPromocao>> ObterHistoricoUsoPromocao(int clienteId)
        {
            return _historicoUsoPromocaoRepository.ObterPorCliente(clienteId);
        }
    }
}
