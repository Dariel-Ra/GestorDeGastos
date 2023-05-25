using System.Data;
using Ardalis.ApiEndpoints;
using GestorDeGastos.Server.Context;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using GestorDeGastos.Server.Models;
using Microsoft.EntityFrameworkCore;
using GestorDeGastos.Shared.Routes;


namespace GestorDeGastos.Server.Endpoints.Mercancias;

using Request = MercanciaRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(MercanciaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            #region  Validaciones
            var rol = await dbContext.Mercancias.FirstOrDefaultAsync(r => r.MercanciaNombre.ToLower() == request.MercanciaNombre.ToLower(),cancellationToken); 
            if(rol != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre '({request.MercanciaNombre})'.");
            #endregion
            rol = Mercancia.Crear(request);
            dbContext.Mercancias.Add(rol);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Success(rol.MercanciaId);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}