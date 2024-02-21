namespace GestaoPedidos.Domain.Interfaces.Repositories;

public interface IItensPedidoRepository
{
    void Insert(int pedidoId, IEnumerable<int> produtoList);
    void SaveChanges();
}