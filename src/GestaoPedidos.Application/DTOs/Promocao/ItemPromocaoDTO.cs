namespace GestaoPedidos.Application.DTOs.Promocao
{
    public class ItemPromocaoDTO
    {
        public int IdPromocao { get; set; }
        public int IdProduto { get; set; }
        public decimal Desconto { get; set; }
    }
}
