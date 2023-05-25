using Ardalis.ApiEndpoints;
using GestorDeGastos.Server.Context;
using GestorDeGastos.Server.Models;
using GestorDeGastos.Shared.Response;
using GestorDeGastos.Shared.Routes;
using GestorDeGastos.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastos.Server.Endpoints.Mercancias;
using Respuesta = Result<MercanciaResponse>;
using Request = MercanciaRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(MercanciaRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request,CancellationToken cancellationToken = default)
    {
       try
       {
            var rol = await dbContext.Mercancias
            .Where(r=>r.MercanciaId == request.Id)
            .Select(rol=>rol.ToResponse())
            .FirstOrDefaultAsync(cancellationToken);

            if(rol==null)
                return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

            return Respuesta.Success(rol);
       }
       catch(Exception ex)
       {
            return Respuesta.Fail(ex.Message);
       }
    }
}
