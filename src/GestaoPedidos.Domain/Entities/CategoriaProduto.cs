namespace GestaoPedidos.Domain.Entities
{
    public class CategoriaProduto : Entidade
    {
        public string Nome { get; private set; }
        public virtual IEnumerable<Produto>? Produtos { get; private set; }
        public CategoriaProduto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
