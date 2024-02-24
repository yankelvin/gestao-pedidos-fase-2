using GestaoPedidos.Domain.Enums;

namespace GestaoPedidos.Domain.Entities
{
    public class Pagamento : Entidade
    {
        public Pagamento(int id, int idPedido, StatusPagamento status)
        {
            Id = id;
            Status = status;
            IdPedido = idPedido;
        }

        public int IdPedido { get; set; }
        public StatusPagamento Status { get; set; }
    }
}
