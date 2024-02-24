using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IPagamentoService
    {
        Task CadastrarPagamento(Pagamento pagamento);
        Task AtualizarPagamento(Pagamento pagamento);
        Task<IEnumerable<Pagamento>> ObterPagamento();
        Task<Pagamento?> ObterPagamento(int pagamentoId);
        Task<IEnumerable<Pagamento>> ObterPagamentoPorPedido(int pedidoId);
        Task RemoverPagamento(int pagamentoId);
    }
}
