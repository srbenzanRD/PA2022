using System.ComponentModel.DataAnnotations;
namespace PA2022.Data.Models;

public class Persona
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
}