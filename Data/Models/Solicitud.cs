namespace PA2022.Data.Models;

public class Solicitud{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public virtual ICollection<SolicitudSustentante>? Sustentantes {get; set;}

    public static Solicitud Crear(List<Persona> personas){
        var sustentantes = new List<SolicitudSustentante>();
        personas.ForEach(persona=>{
            sustentantes.Add(new SolicitudSustentante(){ personaId = persona.Id, persona = persona });
        });
        return new Solicitud(){
                Fecha = DateTime.Now,
                Sustentantes = sustentantes,
        };
    }
}