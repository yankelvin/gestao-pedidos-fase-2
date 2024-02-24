using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Application.DTOs.Pagamento;
using GestaoPedidos.Infrastructure.Data.Entities.Pagamentos;

namespace GestaoPedidos.Application.Mappings
{
    public class PagamentoMappingProfile : Profile
    {
        public PagamentoMappingProfile()
        {
            CreateMap<Pagamento, PagamentoDTO>();
            CreateMap<Pagamento, PagamentoEntity>();
            CreateMap<PagamentoEntity, Pagamento>().ConstructUsing(p => new Pagamento(p.Id, p.IdPedido, p.Status));
            CreateMap<PagamentoDTO, Pagamento>().ConstructUsing(p => new Pagamento(p.Id, p.IdPedido, p.Status));
        }
    }
}
