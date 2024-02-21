using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task CadastrarCliente(Cliente cliente);
        bool AtualizarCliente(Cliente cliente);
        Cliente? ObterCliente(string cpf);
        bool DeletarCliente(int id);
    }
}
