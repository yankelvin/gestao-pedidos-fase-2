using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories;

public interface IPagamentoRepository
{
    Task<IEnumerable<Pagamento>> ObterPorPedido(int pedidoId);
    Task<IEnumerable<Pagamento>> Obter();
    Task<Pagamento?> Obter(int pagamentoId);
    Task Cadastrar(Pagamento pagamento);
    Task Atualizar(Pagamento pagamento);
    Task Remover(int pagamentoId);
}