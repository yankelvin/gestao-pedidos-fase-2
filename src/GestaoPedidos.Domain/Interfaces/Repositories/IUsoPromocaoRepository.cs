namespace GestaoPedidos.Domain.Interfaces.Repositories;

public interface IUsoPromocaoRepository
{
    Task Executar(int clienteId, int promocaoId);
}