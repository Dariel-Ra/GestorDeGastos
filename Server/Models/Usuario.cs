using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDeGastos.Shared.Requests;
using GestorDeGastos.Shared.Response;

namespace GestorDeGastos.Server.Models;

public class Usuario
{
    public Usuario()
    {
        
    }
    [Key]
    public int UsuarioId { get; set; }
    [StringLength(45)]
    public string Nombre { get; set; } = null!;
    [StringLength(45)]
    public string Apellido { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Estado { get; set; }

    public static Usuario Crear(UsuarioRequest request)
    {
        return new Usuario(){ 
             
            Nombre = request.Nombre,
            Apellido = request.Apellido, 
            Password = request.Password,
            Estado = request.Estado 
            };
        // return new Usuario(request.UsuarioRolId,request.Name, request.Nickname, request.Password);
    }

    public UsuarioResponse ToResponse()
    {
        return new UsuarioResponse(UsuarioId, Nombre, Apellido, Password, Estado);
    }
}

