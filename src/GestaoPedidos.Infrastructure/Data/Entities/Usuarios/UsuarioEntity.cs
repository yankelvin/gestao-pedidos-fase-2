using System.ComponentModel.DataAnnotations.Schema;
using GestaoPedidos.Infrastructure.Data.Entities;

namespace GestaoPedidos.Infrastructure.Data.Entities.Usuarios
{
    [Table("usuario")]
    public class UsuarioEntity : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
