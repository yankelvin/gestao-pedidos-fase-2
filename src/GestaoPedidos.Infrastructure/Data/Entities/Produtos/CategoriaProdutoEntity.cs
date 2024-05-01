using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedidos.Infrastructure.Data.Entities.Produtos
{
    [Table("categoria_produto")]
    public class CategoriaProdutoEntity : Entity
    {
        public string Nome { get; set; }
    }
}
