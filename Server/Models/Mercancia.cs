﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Response;

namespace GestorDeGastos.Server.Models;

public class Mercancia
{
    [Key]
    public int MercanciaId { get; set; }
    public string MercanciaNombre { get; set; } = null!;
    public string MercanciaDescripcion { get;set; } = null!;       
    
    public static Mercancia Crear(MercanciaRequest request)
    {
        return new Mercancia(){
            MercanciaNombre = request.MercanciaNombre,
            MercanciaDescripcion = request.MercanciaDescripcion
        };
    }
    public MercanciaResponse ToResponse()
    {
        return new MercanciaResponse (MercanciaId, MercanciaNombre, MercanciaDescripcion);
    }
}

public class Empleado{
    [Key]
    public int EmpleadoId {get; set; }
    public string NombreCompleto { get; set; } = null!;
    public bool Estado { get; set; }

}

public class Nomina{
    [Key]
    public int Nominaid { get; set; }
    public int EmpleadoId { get; set; }
    public virtual Empleado Empleado { get; set; } = null!;
}

public class GastosGenerales{
    [Key]
    public int GastoGeneralesId { get; set; }
    public DateTime Fecha { get; set; }
    public int Nominaid { get; set; }
    public virtual Nomina Nomina { get; set; } = null!;
    public int GastosMercanciaId { get; set; }
    public virtual GastosMercancia GastosMercancia { get; set; } = null!;
    public int GastosProveedorId { get; set; }
    public virtual GastosProveedor GastosProveedor { get; set; } = null!;
    public int GastosMiscelaneoId { get; set; }
    public virtual GastosMiscelaneo GastoMiscelaneo { get; set; } = null!;
} 

public class GastosMiscelaneo{
    [Key]
    public int GastosMiscelaneoId { get; set; }
    public DateTime Fecha { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descricción { get; set; } = null!;
    public int Cantidad { get; set; }
    
}

public class GastosProveedor{
    [Key]
    public int GastosProveedorId { get; set; }
    public DateTime Fecha { get; set; }
    public string Descricción { get; set; } = null!;
    public decimal Gastos { get; set; }
}
 

public class GastosMercancia{
    [Key]
    public int GastosMercanciaId { get; set; }
    [Column(TypeName="Date")]
    public DateTime Fecha { get; set; }
    public int Cantidad { get; set; }
    public string Descricción { get; set; } = null!;
    public int MercanciaId { get; set; }
    public virtual Mercancia Mercancia { get; set; } = null!;

    public static GastosMercancia Crear(GastosMercanciaRequest request)
    {
        return new GastosMercancia(){ 
             
            Fecha = request.Fecha,
            Cantidad = request.Cantidad, 
            Descricción = request.Descricción,
            MercanciaId = request.MercanciaId 
        };
    }

    public GastosMercanciaResponse ToResponse()
    {
        return new GastosMercanciaResponse(GastosMercanciaId, Fecha, Cantidad, Descricción, Mercancia.ToResponse());
    }
}
