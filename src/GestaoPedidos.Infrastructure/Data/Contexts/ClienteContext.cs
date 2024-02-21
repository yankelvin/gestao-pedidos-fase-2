using GestaoPedidos.Infrastructure.Data.Entities.Clientes;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Contexts
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }
        public DbSet<ClienteEntity> Clientes { get; set; }
    }
}
