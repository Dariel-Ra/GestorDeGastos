using System.Data;
using Ardalis.ApiEndpoints;
using GestorDeGastos.Server.Context;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using GestorDeGastos.Server.Models;
using Microsoft.EntityFrameworkCore;
using GestorDeGastos.Shared.Routes;


namespace GestorDeGastos.Server.Endpoints.GastosMercancias;

using Request = GastosMercanciaRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(GastosMercanciaRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            #region  Validaciones
            var rol = await dbContext.GastosMercancias.FirstOrDefaultAsync(r => r.Fecha.ToString().ToLower() == request.Fecha.ToString().ToLower(),cancellationToken); 
            if(rol != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre '({request.Fecha})'.");
            #endregion
            rol = GastosMercancia.Crear(request);
            dbContext.GastosMercancias.Add(rol);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Success(rol.MercanciaId);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}