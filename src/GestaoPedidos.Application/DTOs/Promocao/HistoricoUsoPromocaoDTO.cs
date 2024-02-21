namespace GestaoPedidos.Application.DTOs.Promocao
{
    public class HistoricoUsoPromocaoDTO
    {
        public int IdPromocao { get; set; }
        public int IdCliente { get; set; }
        public bool Utilizado { get; set; }
    }
}
