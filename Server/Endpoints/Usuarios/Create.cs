using System.Net.Cache;
using System.Data;
using Ardalis.ApiEndpoints;
using GestorDeGastos.Server.Context;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using GestorDeGastos.Server.Models;
using Microsoft.EntityFrameworkCore;
using GestorDeGastos.Shared.Routes;


namespace GestorDeGastos.Server.Endpoints.Usuarios;

using Request = UsuarioRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;

    public Create(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpPost(UsuarioRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            #region  Validaciones
            var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(
                r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken); 
            if(usuario != null)
                return Respuesta.Fail($"Ya existe un rol con el nombre '({request.Nombre})'.");
            #endregion
            usuario = Usuario.Crear(request);
            dbContext.Usuarios.Add(usuario);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Success(usuario.UsuarioId);
        }
        catch(Exception e){
            return Respuesta.Fail(e.Message);
        }
    }
}