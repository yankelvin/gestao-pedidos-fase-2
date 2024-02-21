using AutoMapper;
using GestaoPedidos.Application.DTOs.Usuario;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Infrastructure.Data.Entities.Usuarios;

namespace GestaoPedidos.Application.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, UsuarioEntity>();
            CreateMap<UsuarioEntity, Usuario>().ConstructUsing(p => new Usuario(p.Id, p.Nome, p.Email, p.Senha, p.Tipo, p.Ativo));
            CreateMap<UsuarioDTO, Usuario>().ConstructUsing(p => new Usuario(p.Id, p.Nome, p.Email, p.Senha, p.Tipo, p.Ativo));
        }
    }
}
