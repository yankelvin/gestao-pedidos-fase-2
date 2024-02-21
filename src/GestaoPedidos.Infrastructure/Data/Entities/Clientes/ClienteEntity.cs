using GestaoPedidos.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoPedidos.Infrastructure.Data.Entities.Clientes;

[Table("cliente")]
public class ClienteEntity : Entity
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime Aniversario { get; set; }
}