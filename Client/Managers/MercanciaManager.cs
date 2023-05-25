using GestorDeGastos.Shared.Wrapper;
using GestorDeGastos.Shared.Response;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Routes;
using GestorDeGastos.Client.Extensions;
using System.Net.Http.Json;

namespace GestorDeGastos.Client.Managers;

public interface IMercanciaManager
{
    Task<ResultList<MercanciaResponse>> GetAsync();
    Task<Result<int>> CreateAsync(MercanciaRequest request);
    Task<Result<MercanciaResponse>> GetByIdAsync(int Id);
}

public class MercanciaManager : IMercanciaManager
{
    private readonly HttpClient httpClient;

    public MercanciaManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<MercanciaResponse>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(MercanciaRouteManager.BASE);
            var resultado = await response.ToResultList<MercanciaResponse>();
            return resultado;
        }
        catch (Exception e)
        {
            return ResultList<MercanciaResponse>.Fail(e.Message);
        }
    }
    public async Task<Result<int>> CreateAsync(MercanciaRequest request)
    {
       var response = await httpClient.PostAsJsonAsync(MercanciaRouteManager.BASE,request);
       return await response.ToResult<int>();
    }
    public async Task<Result<MercanciaResponse>> GetByIdAsync(int Id)
    {
       var response = await httpClient.GetAsync(MercanciaRouteManager.BuildRoute(Id));
       return await response.ToResult<MercanciaResponse>();
    }
}
