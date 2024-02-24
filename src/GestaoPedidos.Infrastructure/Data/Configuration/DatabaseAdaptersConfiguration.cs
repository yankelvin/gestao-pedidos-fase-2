using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoPedidos.Infrastructure.Data.Configuration
{
    public static class DatabaseAdaptersConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<PromocaoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ProdutoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<UsuarioContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ClienteContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<PedidoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ItensPedidoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<PagamentoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());

            services.AddTransient<IPromocaoRepository, PromocaoRepository>();
            services.AddTransient<IItemPromocaoRepository, ItemPromocaoRepository>();
            services.AddTransient<IHistoricoUsoPromocaoRepository, HistoricoUsoPromocaoRepository>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICategoriaProdutoRepository, CategoriaProdutoRepository>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItensPedidoRepository, ItensPedidoRepository>();

            services.AddTransient<IPagamentoRepository, PagamentoRepository>();
            return services;
        }
    }
}
