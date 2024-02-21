using GestaoPedidos.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedidos.Infrastructure.Data.Entities.Produtos
{
    [Table("produto")]
    public class ProdutoEntity : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int IdCategoria { get; set; }
    }
}
