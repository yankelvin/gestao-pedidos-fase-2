using GestaoPedidos.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedidos.Infrastructure.Data.Entities.Pagamentos
{
    [Table("pagamento")]
    public class PagamentoEntity : Entity
    {
        public int IdPedido { get; set; }
        public StatusPagamento Status { get; set; }
    }
}
