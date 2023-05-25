using GestorDeGastos.Shared.Wrapper;
using GestorDeGastos.Shared.Response;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Routes;
using GestorDeGastos.Client.Extensions;
using System.Net.Http.Json;

namespace GestorDeGastos.Client.Managers;

public interface IUsuarioManager
{
    Task<Result<int>> CreateAsync(UsuarioRequest request);
    Task<ResultList<UsuarioResponse>> GetAsync();
    Task<Result<UsuarioResponse>> GetByIdAsync(int Id);
}

public class UsuarioManager : IUsuarioManager
{
    private readonly HttpClient httpClient;

    public UsuarioManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<ResultList<UsuarioResponse>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioResponse>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<UsuarioResponse>.Fail(e.Message);
        }
    }
    public async Task<Result<int>> CreateAsync(UsuarioRequest request)
    {
        var response = await httpClient.PostAsJsonAsync(UsuarioRouteManager.BASE, request);
        return await response.ToResult<int>();
    }
    public async Task<Result<UsuarioResponse>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync(UsuarioRouteManager.BuildRoute(Id));
        return await response.ToResult<UsuarioResponse>();
    }
}