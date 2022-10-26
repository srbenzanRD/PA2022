namespace PA2022.Data.Models;

public class Solicitud{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public virtual ICollection<SolicitudSustentante>? Sustentantes {get; set;}
}