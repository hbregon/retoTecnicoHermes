using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdministadorTareasAPI.Models
{
    public class Colaborador
    {
        public Colaborador()
        {
            Tareas = new HashSet<Tarea>();
        }
        [Key]
        public int? IdColaborador { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
