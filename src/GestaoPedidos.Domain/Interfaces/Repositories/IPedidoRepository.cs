using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Enums;

namespace GestaoPedidos.Domain.Interfaces.Repositories;

public interface IPedidoRepository
{
    void Inserir(Pedido pedido, IEnumerable<int> produtos);
    Pedido Obter(int id);
    bool Deletar(int id);
    bool Atualizar(Pedido pedido);
    IEnumerable<Pedido> ObterPorCliente(int? idCliente);
    public void SaveChanges();
    IEnumerable<Pedido> ObterTodosPedidos(int? idCliente, Status? statusPedido);
}