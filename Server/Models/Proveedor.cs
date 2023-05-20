using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;


namespace GestorDeGastos.Server.Models;

    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public bool Estado { get; set; }
    }

