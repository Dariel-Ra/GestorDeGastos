using Ardalis.ApiEndpoints;
using GestorDeGastos.Server.Context;
using GestorDeGastos.Server.Models;
using GestorDeGastos.Shared.Response;
using GestorDeGastos.Shared.Routes;
using GestorDeGastos.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorDeGastos.Server.Endpoints.Usuarios;
using Respuesta = Result<UsuarioResponse>;
using Request = UsuarioRouteManager;

public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRouteManager.GetById)]
    public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request,CancellationToken cancellationToken = default)
    {
       try
       {
            var usuario = await dbContext.Usuarios
            .Where(r=>r.UsuarioId == request.Id)
            .Select(usuario=>usuario.ToResponse())
            .FirstOrDefaultAsync(cancellationToken);

            if(usuario==null)
                return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

            return Respuesta.Success(usuario);
       }
       catch(Exception ex)
       {
            return Respuesta.Fail(ex.Message);
       }
    }
}
