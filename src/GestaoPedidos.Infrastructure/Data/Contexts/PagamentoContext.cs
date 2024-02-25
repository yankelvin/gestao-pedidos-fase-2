using GestaoPedidos.Infrastructure.Data.Entities.Pagamentos;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Contexts
{
    public class PagamentoContext : DbContext
    {
        public PagamentoContext(DbContextOptions<PagamentoContext> options) : base(options) { }
        public DbSet<PagamentoEntity> Pagamentos { get; set; }
    }
}
