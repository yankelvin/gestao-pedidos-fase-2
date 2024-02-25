using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Enums;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<int> CadastrarPedido(int idCliente, IEnumerable<int> produtoList)
        {
            if (_clienteRepository.NaoExiste(idCliente))
                throw new ArgumentException("Cliente informado não existe");

            var pedido = await ComplementaDadosPeddidoAsync(idCliente, produtoList);
            _pedidoRepository.Inserir(pedido, produtoList);
            _pedidoRepository.SaveChanges();

            return pedido.Id;
        }

        private async Task<Pedido> ComplementaDadosPeddidoAsync(int idCliente, IEnumerable<int> produtoIdList)
        {
            var produtoList = await _produtoRepository.Obter();

            return new()
            {
                Id = Convert.ToInt32(new Random().Next(100, 1000000).ToString("D4")),
                DataPedido = DateTime.Now,
                HorarioInicio = DateTime.Now,
                Status = Status.Solicitado,
                ValorPedido = produtoList.Where(p => produtoIdList.Contains(p.Id)).Sum(p => p.Preco),
                IdCliente = idCliente
            };
        }

        public bool AtualizarPedido(Pedido pedido)
        {
            return _pedidoRepository.Atualizar(pedido);
        }

        public Pedido ObterPedido(int id)
        {
            return _pedidoRepository.Obter(id);
        }

        public IEnumerable<Pedido> ObterTodosPedidos(int? idCliente, Status? statusPedido)
        {
            return _pedidoRepository.ObterTodosPedidos(idCliente, statusPedido);
        }

        public bool DeletarPedido(int id)
        {
            return _pedidoRepository.Deletar(id);
        }

        public Status ProximaEtapaPedido(int idPedido)
        {
            var pedido = _pedidoRepository.Obter(idPedido);

            pedido.Status = ProximoEtapaStatus(pedido.Status);

            if (pedido.Status is Status.Pronto)
                pedido.HorarioFim = DateTime.Now;

            _pedidoRepository.Atualizar(pedido);
            return pedido.Status;
        }

        private Status ProximoEtapaStatus(Status status)
        {
            if (status is Status.Finalizado)
                return Status.Finalizado;

            var statusAtual = (int)status;

            return (Status)(statusAtual + 1);
        }
    }
}
