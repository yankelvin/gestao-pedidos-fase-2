using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories
{
    public interface IHistoricoUsoPromocaoRepository
    {
        Task InserirUsoPromocao(HistoricoUsoPromocao historicoUsoPromocao);
        Task<IEnumerable<HistoricoUsoPromocao>> ObterPorCliente(int clienteId);
    }
}
