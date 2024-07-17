using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdministadorTareasAPI.Models;
using System.ComponentModel.Design;
using System.Collections;
using Microsoft.AspNetCore.Cors;

namespace AdministadorTareasAPI.Controllers
{
    [EnableCors("ReglasCORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DBContexto _contexto;

        public TareaController(DBContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult GetTareas()
        {
            List<Tarea> lista = new List<Tarea>();
            try
            {
                //lista = _contexto.Tareas.ToList();   PARA OBTENER SOLO LAS TAREAS SIN COLABORADOR
                lista = _contexto.Tareas.Include(c => c.ObjetoColaborador).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", respuesta = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message, respuesta = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idTarea:int}")]
        public IActionResult GetTarea(int idTarea)
        {
            Tarea tarea = new Tarea();
            tarea = _contexto.Tareas.Find(idTarea);

            if (tarea == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Tarea no encontrada"}); 
            }

            try
            {
                if (tarea.IdColaborador != 0)
                {
                    tarea = _contexto.Tareas.Include(c => c.ObjetoColaborador).Where(t => t.IdTarea == idTarea).FirstOrDefault();
                }
                else
                {
                    tarea = _contexto.Tareas.Where(t => t.IdTarea == idTarea).FirstOrDefault();
                }
                
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", respuesta = tarea });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message, respuesta = tarea });
            }
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Guardar")]
        public IActionResult PostTarea([FromBody] Tarea tarea)
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
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Se ha creado la tarea con éxito"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message });
            }
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Editar")]
        public IActionResult PutTarea([FromBody] Tarea tareaParametro)
        {
            Tarea tarea = new Tarea();
            tarea = _contexto.Tareas.Find(tareaParametro.IdTarea);

            if (tarea == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Tarea no encontrada" });
            }

            try
            {
                tarea.Descripcion = tareaParametro.Descripcion is null ? tarea.Descripcion : tareaParametro.Descripcion;
                tarea.Estado = tareaParametro.Estado is null ? tarea.Estado : tareaParametro.Estado;
                tarea.Prioridad = tareaParametro.Prioridad is null ? tarea.Prioridad : tareaParametro.Prioridad;
                tarea.FechaInicio = tareaParametro.FechaInicio is null ? tarea.FechaInicio : tareaParametro.FechaInicio;
                tarea.FechaFin = tareaParametro.FechaFin is null ? tarea.FechaFin : tareaParametro.FechaFin;
                tarea.IdColaborador = tareaParametro.IdColaborador is null ? tarea.IdColaborador : tareaParametro.IdColaborador;
                tarea.Nota = tareaParametro.Nota is null ? tarea.Nota : tareaParametro.Nota;

                _contexto.Tareas.Update(tarea);
                _contexto.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha modificado la tarea con éxito"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message});
            }
        }

        // DELETE: api/Tareas/5
        [HttpDelete]
        [Route("Eliminar/{idTarea:int}")]
        public IActionResult DeleteTarea(int idTarea)
        {
            Tarea tarea = _contexto.Tareas.Find(idTarea);
            if (tarea == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Tarea no encontrada" });
            }

            try
            {
                _contexto.Tareas.Remove(tarea);
                _contexto.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha eliminado la tarea con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message });
            }
        }

    }
}
