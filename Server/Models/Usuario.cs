using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeGastos.Server.Models;

    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [StringLength(45)]
        public string Nombre { get; set; } = null!;
        [StringLength(45)]
        public string Apellido { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Estado { get; set; }
    }

