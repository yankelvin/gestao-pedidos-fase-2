using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories
{
    public interface IPromocaoRepository
    {
        Task<IEnumerable<Promocao>> Obter();
        Task<Promocao?> Obter(int promocaoId);
        Task Cadastrar(Promocao promocao);
        Task Atualizar(Promocao promocao);
        Task Remover(int promocaoId);
        void RegistrarUsoPromocao(int clienteId, int promocaoId);
        Task<bool> NaoExiste(int promocaoId);
    }
}
