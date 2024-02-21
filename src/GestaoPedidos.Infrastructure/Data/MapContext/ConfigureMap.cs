using GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;
using GestaoPedidos.Infrastructure.Data.MapContext.EntitiesMap;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.MapContext;

public static class ConfigureMap
{
    public static void Config(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensPedidoEntity>(new ItensPedidoMap().Configure);
    }
}