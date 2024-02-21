using Microsoft.EntityFrameworkCore;
using GestaoPedidos.Infrastructure.Data.MapContext;
using GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;
using GestaoPedidos.Infrastructure.Data.Entities.Pedidos;

namespace GestaoPedidos.Infrastructure.Data.Contexts;

public class PedidoContext : DbContext
{
    public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }
    public DbSet<PedidoEntity> Pedidos { get; set; }
    public DbSet<ItensPedidoEntity> ItensPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureMap.Config(modelBuilder);


    }
}