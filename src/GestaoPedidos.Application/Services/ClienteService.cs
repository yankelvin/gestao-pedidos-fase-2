using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CadastrarCliente(Cliente cliente)
        {
            if (_clienteRepository.ExistePorCpf(cliente.CPF))
                throw new ArgumentException("Usuário já cadastrado");

            await _clienteRepository.InserirAsync(cliente);
        }

        public bool AtualizarCliente(Cliente cliente)
        {
            if (_clienteRepository.Existe(cliente.Id))
                return _clienteRepository.Atualizar(cliente);

            return false;
        }

        public Cliente? ObterCliente(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public bool DeletarCliente(int id)
        {
            if (_clienteRepository.Existe(id))
                return _clienteRepository.Deletar(id);

            return false;
        }
    }
}
