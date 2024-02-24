using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Enums;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<int> CadastrarPedido(int idCliente, IEnumerable<int> produtoList);
        bool AtualizarPedido(Pedido pedido);
        Pedido ObterPedido(int id);
        IEnumerable<Pedido> ObterTodosPedidos(int? idCliente, Status? statusPedido);
        Status ProximaEtapaPedido(int idPedido);
        bool DeletarPedido(int id);
    }
}
