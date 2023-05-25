namespace GestorDeGastos.Shared.Response;

public class MercanciaResponse
{
    public MercanciaResponse()
    {

    }
    public MercanciaResponse(int mercanciaId, string mercanciaNombre, string mercanciaDescripcion)
    {
        MercanciaId = mercanciaId;
        MercanciaNombre = mercanciaNombre;
        MercanciaDescripcion = mercanciaDescripcion;
    }

    public int MercanciaId { get; set; }
    public string MercanciaNombre { get; set; } = null!;
    public string MercanciaDescripcion { get; set; } = null!;
}

public class ProveedorResponse
{
    public int ProveedorId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public bool Estado { get; set; }
}
public class EmpleadoResponse
{
    public int EmpleadoId { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public bool Estado { get; set; }
}

public class NominaResponse
{
    public int Nominaid { get; set; }
    public EmpleadoResponse Empleado { get; set; } = null!;
}

public class GastoGeneralesResponse
{
    public int GastoGeneralesId { get; set; }
    public NominaResponse Nomina { get; set; } = null!;
    public GastosMercanciaResponse GastoMercancia { get; set; } = null!;
    public GastosProveedorResponse GastoProveedor { get; set; } = null!;
    public GastosMiscelaneoResponse GastosMiscelaneo { get; set; } = null!;
}

public class GastosMiscelaneoResponse
{
    public int GastosMiscelaneoId { get; set; }
    public string Descripcion { get; set; } = null!;
    public int Cantidad { get; set; }
}

public class GastosProveedorResponse
{
    public int GastosProveedorId { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal Gastos { get; set; }
}

public class GastosMercanciaResponse
{
    public int GastosMercanciaId { get; set; }
    public int Cantidad { get; set; }
    public string Descripcion { get; set; } = null!;
    public virtual MercanciaResponse Mercancia { get; set; } = null!;
}
