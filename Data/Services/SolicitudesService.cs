
using Microsoft.EntityFrameworkCore;
using PA2022.Data.Context;
using PA2022.Data.Models;

namespace PA2022.Data.Services;

public class SolicitudesService:ISolicitudesService
{
    private readonly IPa2022DbContext _context;

    public SolicitudesService(IPa2022DbContext context)
    {
        _context = context;
    }

    public async Task<List<Solicitud>> Consultar()
    {
        return await _context.Solicitudes
        .Include(s=>s.Sustentantes)
            .ThenInclude(su=>su.persona)
        .ToListAsync();
    }

        public async Task<bool> Crear(string tema, List<Persona> personas)
    {
        try {
            var solicitud = Solicitud.Crear(tema,personas);
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return true;
        }
        catch{
            return false;
        }
    }
}

public interface ISolicitudesService{
        public Task<List<Solicitud>> Consultar();

        public Task<bool> Crear(string tema, List<Persona> personas);

}