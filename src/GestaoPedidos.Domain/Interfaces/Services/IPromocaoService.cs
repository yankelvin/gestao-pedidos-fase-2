using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IPromocaoService
    {
        Task CadastrarPromocao(Promocao promocao);
        Task AtualizarPromocao(Promocao promocao);
        Task<IEnumerable<Promocao>> ObterPromocao();
        Task<Promocao?> ObterPromocao(int promocaoId);
        Task RemoverPromocao(int promocaoId);
    }
}
