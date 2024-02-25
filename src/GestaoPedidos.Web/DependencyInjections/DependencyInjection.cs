using GestaoPedidos.Application.Mappings;
using GestaoPedidos.Application.Services;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Web.DependencyInjections
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ICategoriaProdutoService, CategoriaProdutoService>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IClienteService, ClienteService>();

            services.AddTransient<IPedidoService, PedidoService>();

            services.AddTransient<IPromocaoService, PromocaoService>();
            services.AddTransient<IItemPromocaoService, ItemPromocaoService>();
            services.AddTransient<IHistoricoUsoPromocaoService, HistoricoUsoPromocaoService>();

            services.AddTransient<IPagamentoService, PagamentoService>();
        }

        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClienteMappingProfile));
            services.AddAutoMapper(typeof(PedidoMappingProfile));
            services.AddAutoMapper(typeof(ProdutoMappingProfile));
            services.AddAutoMapper(typeof(PromocaoMappingProfile));
            services.AddAutoMapper(typeof(UsuarioMappingProfile));
            services.AddAutoMapper(typeof(PagamentoMappingProfile));
        }
    }
}
