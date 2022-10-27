using Microsoft.EntityFrameworkCore;
using PA2022.Data.Models;
namespace PA2022.Data.Context;

public class Pa2022DbContext : DbContext,IPa2022DbContext
{
    public Pa2022DbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Persona> Personas {get;set;} = null!;
    public DbSet<Solicitud> Solicitudes {get;set;} = null!;
    public DbSet<SolicitudSustentante> SolicitudesSustentantes {get;set;} = null!;

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

public interface IPa2022DbContext{
    public DbSet<Persona> Personas {get;set;}
    public DbSet<Solicitud> Solicitudes {get;set;}
    public DbSet<SolicitudSustentante> SolicitudesSustentantes {get;set;}
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
