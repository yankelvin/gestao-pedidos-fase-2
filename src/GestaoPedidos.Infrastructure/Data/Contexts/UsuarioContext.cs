using GestaoPedidos.Infrastructure.Data.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Infrastructure.Data.Contexts
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
