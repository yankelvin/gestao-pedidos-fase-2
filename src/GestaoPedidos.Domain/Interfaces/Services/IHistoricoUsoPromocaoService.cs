using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IHistoricoUsoPromocaoService
    {
        Task CadastrarHistoricoUsoPromocao(HistoricoUsoPromocao historicoUsoPromocao);
        Task<IEnumerable<HistoricoUsoPromocao>> ObterHistoricoUsoPromocao(int clienteId);
    }
}
