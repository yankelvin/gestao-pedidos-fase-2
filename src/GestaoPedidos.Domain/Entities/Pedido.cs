using GestaoPedidos.Domain.Enums;

namespace GestaoPedidos.Domain.Entities;

public class Pedido : Entidade
{
    public DateTime DataPedido { get; set; }
    public Status Status { get; set; }
    public int IdCliente { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFim { get; set; }
    public decimal ValorPedido { get; set; }
}