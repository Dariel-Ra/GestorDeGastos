using Microsoft.EntityFrameworkCore;
using GestorDeGastos.Server.Models;

namespace CrudBlazor.Server.Context;

public interface IMyDbContext
{
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<Mercancia> Mercancias { set; get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("CRUD"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<Mercancia> Mercancias { set; get; } = null!;
    public DbSet<Usuario> Usuarios { set; get; } = null!;
    #endregion
}