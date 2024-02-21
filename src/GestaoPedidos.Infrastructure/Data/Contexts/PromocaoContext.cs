using GestaoPedidos.Infrastructure.Data.Entities.Promocoes;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Contexts
{
    public class PromocaoContext : DbContext
    {
        public PromocaoContext(DbContextOptions<PromocaoContext> options) : base(options) { }

        public DbSet<PromocaoEntity> Promocoes { get; set; }
        public DbSet<ItemPromocaoEntity> ItensPromocoes { get; set; }
        public DbSet<HistoricoUsoPromocaoEntity> HistoricosUsoPromocoes { get; set; }
    }
}
