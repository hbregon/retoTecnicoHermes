using AdministadorTareasAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministadorTareasAPI.Controllers
{
    [EnableCors("ReglasCORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly DBContexto _contexto;

        public NotaController(DBContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("ObtenerNotasAsociadas/{idTarea:int}")]
        public IActionResult GetNotas(int idTarea)
        {
            List<Nota> lista = new List<Nota>();
            Tarea tarea = _contexto.Tareas.Find(idTarea);

            if (tarea == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Tarea no tiene notas asociadas" });
            }

            try
            {
                lista = _contexto.Notas.Include(n => n.ObjetoTarea).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", respuesta = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message, respuesta = tarea });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult PostNota([FromBody] Tarea tarea)
        {
            try
            {
                if (tarea.IdColaborador == 0)
                {
                    tarea.IdColaborador = null;
                    tarea.ObjetoColaborador = null;
                }
                _contexto.Tareas.Add(tarea);
                _contexto.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Se ha creado la tarea con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message });
            }
        }
    }
}
