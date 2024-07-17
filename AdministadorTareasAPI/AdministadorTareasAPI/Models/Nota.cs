using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AdministadorTareasAPI.Models
{
    public class Nota
    {
        [Key]
        public int? IdNota { get; set; }
        public string? CuerpoNota { get; set; }
        public int? IdTarea { get; set; }
        [JsonIgnore]
        public virtual Tarea? ObjetoTarea { get; set; }
    }
}
