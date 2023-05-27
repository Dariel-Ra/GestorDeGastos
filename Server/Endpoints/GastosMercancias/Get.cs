using Ardalis.ApiEndpoints;
using GestorDeGastos.Server.Context;
using GestorDeGastos.Server.Models;
using GestorDeGastos.Shared.Response;
using GestorDeGastos.Shared.Routes;
using GestorDeGastos.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanHouse.Server.Endpoints.GastosMercancias;
using Respuesta = ResultList<GastosMercanciaResponse>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(GastosMercanciaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(CancellationToken cancellationToken = default)
    {
       try
       {
        var roles = await dbContext.GastosMercancias
        .Include(m=>m.Mercancia)
        .Select(rol=>rol.ToResponse())
        .ToListAsync(cancellationToken);

        return Respuesta.Success(roles);
        }
        catch(Exception ex)
        {
        return Respuesta.Fail(ex.Message);
        }
    }
}
