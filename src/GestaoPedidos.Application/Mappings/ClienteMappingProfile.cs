using AutoMapper;
using GestaoPedidos.Application.DTOs.Cliente;
using GestaoPedidos.Infrastructure.Data.Entities.Clientes;

namespace GestaoPedidos.Application.Mappings;

public class ClienteMappingProfile : Profile
{
    public ClienteMappingProfile()
    {
        CreateMap<Domain.Entities.Cliente, CadastroClienteDto>();
        CreateMap<CadastroClienteDto, Domain.Entities.Cliente>();

        CreateMap<Domain.Entities.Cliente, ClienteDTO>();
        CreateMap<ClienteDTO, Domain.Entities.Cliente>();

        CreateMap<AtualizarClienteDTO, Domain.Entities.Cliente>();
        CreateMap<Domain.Entities.Cliente, AtualizarClienteDTO>();

        CreateMap<ClienteEntity, Domain.Entities.Cliente>().ReverseMap();
    }
}