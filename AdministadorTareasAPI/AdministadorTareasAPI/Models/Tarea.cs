using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Threading;

namespace AdministadorTareasAPI.Models
{
    public class Tarea
    {
        [Key]
        public int? IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        [AllowNull]
        public int? IdColaborador { get; set; }
        [JsonIgnore]
        public virtual Colaborador? ObjetoColaborador { get; set; }
        public string? Nota { get; set; }
    }
}
