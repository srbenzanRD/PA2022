namespace PA2022.Data.Models;

public class SolicitudSustentante
{
    public int Id { get; set; }
    public int solicitudId { get; set; }
    public virtual Solicitud? solicitud {get; set;}
    public int personaId { get; set; }
    public virtual Persona? persona {get; set;}
}