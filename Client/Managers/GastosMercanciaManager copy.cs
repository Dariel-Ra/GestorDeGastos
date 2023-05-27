using GestorDeGastos.Shared.Wrapper;
using GestorDeGastos.Shared.Response;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Routes;
using GestorDeGastos.Client.Extensions;
using System.Net.Http.Json;

namespace GestorDeGastos.Client.Managers;

public interface IGastosMercanciaManager
{
    Task<ResultList<GastosMercanciaResponse>> GetAsync();
    Task<Result<int>> CreateAsync(GastosMercanciaRequest request);
    Task<Result<GastosMercanciaResponse>> GetByIdAsync(int Id);
}

public class GastosMercanciaManager : IGastosMercanciaManager
{
    private readonly HttpClient httpClient;

    public GastosMercanciaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<GastosMercanciaResponse>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(GastosMercanciaRouteManager.BASE);
            var resultado = await response.ToResultList<GastosMercanciaResponse>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<GastosMercanciaResponse>.Fail(e.Message);
        }
    }
    public async Task<Result<int>> CreateAsync(GastosMercanciaRequest request)
    {
       var response = await httpClient.PostAsJsonAsync(GastosMercanciaRouteManager.BASE,request);
       return await response.ToResult<int>();
    }
    public async Task<Result<GastosMercanciaResponse>> GetByIdAsync(int Id)
    {
       var response = await httpClient.GetAsync(GastosMercanciaRouteManager.BuildRoute(Id));
       return await response.ToResult<GastosMercanciaResponse>();
    }
}
