using GestaoPedidos.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedidos.Infrastructure.Data.Entities.Promocoes
{
    [Table("promocao")]
    public class PromocaoEntity : Entity
    {
        public string texto { get; set; }
        public bool status { get; set; }
    }
}
