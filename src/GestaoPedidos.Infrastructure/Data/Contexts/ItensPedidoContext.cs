using GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Contexts;

public class ItensPedidoContext : DbContext
{
    public ItensPedidoContext(DbContextOptions<ItensPedidoContext> options) : base(options) { }
    public DbSet<ItensPedidoEntity> ItensPedido { get; set; }
}