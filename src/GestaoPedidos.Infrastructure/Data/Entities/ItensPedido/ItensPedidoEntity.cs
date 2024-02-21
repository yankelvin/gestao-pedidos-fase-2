using System.ComponentModel.DataAnnotations.Schema;
using GestaoPedidos.Infrastructure.Data.Entities.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;

[Table("item_pedido")]
[PrimaryKey(nameof(IdPedido), nameof(IdProduto))]
public class ItensPedidoEntity
{
    public int IdPedido { get; set; }
    public int IdProduto { get; set; }

    public virtual PedidoEntity? Pedido { get; set; }
}