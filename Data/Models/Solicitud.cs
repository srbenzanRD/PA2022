namespace PA2022.Data.Models;

public class Solicitud{
    public Solicitud()
    {
        Sustentantes = new List<SolicitudSustentante>();
    }
    public int Id { get; set; }
    public string Tema { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public virtual ICollection<SolicitudSustentante> Sustentantes {get; set;}

    public static Solicitud Crear(string tema,List<Persona> personas){
        var sustentantes = new List<SolicitudSustentante>();
        personas.ForEach(persona=>{
            sustentantes.Add(new SolicitudSustentante(){ personaId = persona.Id, persona = persona });
        });
        return new Solicitud(){
                Tema = tema,
                Fecha = DateTime.Now,
                Sustentantes = sustentantes,
        };
    }
}