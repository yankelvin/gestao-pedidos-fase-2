using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    Cliente? ObterPorCpf(string cpf);
    bool NaoExiste(int id);
    bool Existe(int id);
    bool ExistePorCpf(string cpf);
    Task InserirAsync(Cliente cliente);
    bool Deletar(int id);
    bool Atualizar(Cliente cliente);
}