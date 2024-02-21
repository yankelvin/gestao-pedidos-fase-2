using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedidos.Infrastructure.Data.Entities.Promocoes
{
    [Table("item_promocao")]
    [PrimaryKey(nameof(idpromocao), nameof(idproduto))]
    public class ItemPromocaoEntity
    {
        public int idpromocao { get; set; }
        public int idproduto { get; set; }
        public decimal desconto { get; set; }
    }
}
