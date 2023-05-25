
namespace GestorDeGastos.Shared.Routes;

public class RouteApiBase
{
    public const string API = "/api";
    public int Id { get; set; }
    public const string IdParameter = "{Id:int}";

}

public class UsuarioRolRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/roles"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class UsuarioRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/users"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class EmpleadoRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/empleados"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class NominaRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/nominas"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class MercanciaRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/mercancias"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class ProveedorRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/proveedores"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class GastosGeneralesRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/gastosgenerales"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class GastosProveedorRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/gastosproveedores"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}
public class GastosMercanciaRouteManager:RouteApiBase
{
   public const string BASE = $"{API}/gastosmercancias"; 
   public const string GetById = $"{BASE}/{IdParameter}";// /api/roles/{Id:int}
   public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}




