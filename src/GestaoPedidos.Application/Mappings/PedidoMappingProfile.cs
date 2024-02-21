using AutoMapper;
using GestaoPedidos.Application.DTOs.Pedido;
using GestaoPedidos.Infrastructure.Data.Entities.Pedidos;

namespace GestaoPedidos.Application.Mappings;

public class PedidoMappingProfile : Profile
{
    public PedidoMappingProfile()
    {
        CreateMap<Domain.Entities.Pedido, PedidoEntity>().ReverseMap();

        CreateMap<Domain.Entities.Pedido, PedidoDTO>().ReverseMap();
        CreateMap<Domain.Entities.Pedido, CadastroPedidoDto>().ReverseMap();
    }
}