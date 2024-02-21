using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Application.Services
{
    public class PromocaoService : IPromocaoService
    {
        private readonly IPromocaoRepository _promocaoRepository;

        public PromocaoService(IPromocaoRepository promocaoRepository)
        {
            _promocaoRepository = promocaoRepository;
        }

        public async Task CadastrarPromocao(Promocao promocao)
        {
            await _promocaoRepository.Cadastrar(promocao);
        }

        public async Task AtualizarPromocao(Promocao promocao)
        {
            await _promocaoRepository.Atualizar(promocao);
        }

        public Task<IEnumerable<Promocao>> ObterPromocao()
        {
            return _promocaoRepository.Obter();
        }

        public Task<Promocao?> ObterPromocao(int promocaoId)
        {
            return _promocaoRepository.Obter(promocaoId);
        }

        public async Task RemoverPromocao(int promocaoId)
        {
            await _promocaoRepository.Remover(promocaoId);
        }
    }
}
