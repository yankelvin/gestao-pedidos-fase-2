using System.ComponentModel.DataAnnotations.Schema;
using GestaoPedidos.Domain.Enums;
using GestaoPedidos.Infrastructure.Data.Entities;
using GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;

namespace GestaoPedidos.Infrastructure.Data.Entities.Pedidos;

[Table("pedido")]
public class PedidoEntity : Entity
{
    public DateTime DataPedido { get; set; }
    public Status Status { get; set; }
    public int IdCliente { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public decimal ValorPedido { get; set; }

    public virtual IEnumerable<ItensPedidoEntity> ItensPedidos { get; set; }
}