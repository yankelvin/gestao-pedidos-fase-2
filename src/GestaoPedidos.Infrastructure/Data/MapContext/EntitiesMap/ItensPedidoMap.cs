using GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedidos.Infrastructure.Data.MapContext.EntitiesMap;

public class ItensPedidoMap : IEntityTypeConfiguration<ItensPedidoEntity>
{
    public void Configure(EntityTypeBuilder<ItensPedidoEntity> builder)
    {
        builder.HasOne(itens => itens.Pedido)
            .WithMany(pedido => pedido.ItensPedidos)
            .HasForeignKey(itensPedido => itensPedido.IdPedido);
    }
}