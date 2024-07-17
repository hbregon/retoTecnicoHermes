using Microsoft.AspNetCore.Mvc;
using AdministadorTareasAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace AdministadorTareasAPI.Controllers
{
    [EnableCors("ReglasCORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly DBContexto _contexto;

        public ColaboradorController(DBContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult GetColaboradores()
        {
            List<Colaborador> lista = new List<Colaborador>();
            try
            {
                lista = _contexto.Colaboradores.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", respuesta = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message, respuesta = lista });
            }
        }
    }
}
