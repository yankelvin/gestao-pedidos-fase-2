using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task CadastrarPagamento(Pagamento pagamento)
        {
            await _pagamentoRepository.Cadastrar(pagamento);
        }

        public async Task AtualizarPagamento(Pagamento pagamento)
        {
            await _pagamentoRepository.Atualizar(pagamento);
        }

        public Task<IEnumerable<Pagamento>> ObterPagamento()
        {
            return _pagamentoRepository.Obter();
        }

        public Task<Pagamento?> ObterPagamento(int pagamentoId)
        {
            return _pagamentoRepository.Obter(pagamentoId);
        }

        public Task<IEnumerable<Pagamento>> ObterPagamentoPorPedido(int pedidoId)
        {
            return _pagamentoRepository.ObterPorPedido(pedidoId);
        }

        public async Task RemoverPagamento(int pagamentoId)
        {
            await _pagamentoRepository.Remover(pagamentoId);
        }

    }
}
