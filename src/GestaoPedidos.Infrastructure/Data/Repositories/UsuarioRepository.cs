using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Entities.Usuarios;

namespace GestaoPedidos.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMapper _mapper;
        private readonly UsuarioContext _usuarioContext;

        public UsuarioRepository(IMapper mapper, UsuarioContext usuarioContext)
        {
            _mapper = mapper;
            _usuarioContext = usuarioContext;
        }

        public async Task Cadastrar(Usuario usuario)
        {
            var entity = _mapper.Map<UsuarioEntity>(usuario);
            await _usuarioContext.Usuarios.AddAsync(entity);
            await _usuarioContext.SaveChangesAsync();
        }

        public async Task Atualizar(Usuario usuario)
        {
            var entity = _mapper.Map<UsuarioEntity>(usuario);
            _usuarioContext.Usuarios.Update(entity);
            await _usuarioContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Usuario>> Obter()
        {
            var entities = _usuarioContext.Usuarios.ToList();
            var usuarios = _mapper.Map<IEnumerable<Usuario>>(entities);
            return Task.FromResult(usuarios);
        }

        public Task<Usuario?> Obter(int usuarioId)
        {
            var entity = _usuarioContext.Usuarios.FirstOrDefault(p => p.Id.Equals(usuarioId));
            if (entity == null)
                throw new KeyNotFoundException($"Identificador do usuario inexistente. {usuarioId}");

            var usuario = _mapper.Map<Usuario>(entity);
            return Task.FromResult(usuario);
        }

        public async Task Remover(int usuarioId)
        {
            var entity = _usuarioContext.Usuarios.FirstOrDefault(p => p.Id.Equals(usuarioId));

            if (entity != null)
            {
                _usuarioContext.Usuarios.Remove(entity);
                await _usuarioContext.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException($"Identificador do usuario inexistente. {usuarioId}");
        }
    }
}
