using AutoMapper;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Infrastructure.Data.Entities.ItensPedido;

namespace GestaoPedidos.Infrastructure.Data.Repositories;

public class ItensPedidoRepository : IItensPedidoRepository
{
    private readonly IMapper _mapper;
    private readonly ItensPedidoContext _itensPedidoContext;

    public ItensPedidoRepository(ItensPedidoContext itensPedidoContext, IMapper mapper)
    {
        _itensPedidoContext = itensPedidoContext;
        _mapper = mapper;
    }

    public void Insert(int pedidoId, IEnumerable<int> produtoList)
    {
        IEnumerable<ItensPedidoEntity> entity = produtoList.Select(MapItensPedido(pedidoId));
        _itensPedidoContext.ItensPedido.AddRange(entity);
    }

    public void SaveChanges()
    {
        _itensPedidoContext.SaveChanges();
    }

    private static Func<int, ItensPedidoEntity> MapItensPedido(int pedidoId)
    {
        return idProduto => new ItensPedidoEntity()
        {
            IdPedido = pedidoId,
            IdProduto = idProduto
        };
    }
}