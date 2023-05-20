namespace GestorDeGastos.Server.Models;

public class Mercancia
{
    public int MercanciaId { get; set; }
    public string MercanciaName { get; set; } = null!;
    public string MercanciaDescription { get;set; } = null!;       
}

public class Empleado{
    public int EmpleadoId {get; set; }
    public string NombreCompleto { get; set; } = null!;
    public bool Estado { get; set; }

}


public class Nomina{
    public int Nominaid { get; set; }
    public int EmpleadoId { get; set; }
    public virtual Empleado Empleado { get; set; } = null!;
}

public class GastoGenerales{
    public int GastoGeneralesId { get; set; }
    public int Nominaid { get; set; }
    public virtual Nomina Nomina { get; set; } = null!;
    public int GastosMercanciaId { get; set; }
    public virtual GastosMercancia GastoMercancia { get; set; } = null!;
    public int GastosProveedorId { get; set; }
    public virtual GastosProveedor GastoProveedor { get; set; } = null!;
    public virtual GastosMiscelaneo GastosMiscelaneo { get; set; } = null!;
} 

public class GastosMiscelaneo{
    public int GastosMiscelaneoId { get; set; }
    public string Descricción { get; set; } = null!;
    public int Cantidad { get; set; }
}

public class GastosProveedor{
    public int GastosProveedorId { get; set; }
    public string Descricción { get; set; } = null!;
    public decimal Gastos { get; set; }

}

public class GastosMercancia{
    public int GastosMercanciaId { get; set; }
    public int Cantidad { get; set; }
    public int Descricción { get; set; }

}
