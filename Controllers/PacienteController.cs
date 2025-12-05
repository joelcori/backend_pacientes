using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDPacientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DbClinicaContext dbContext;

        public PacienteController(DbClinicaContext _dbContext)
        {
            dbContext = _dbContext;
        }

        // LISTA
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaPaciente = await dbContext.Pacientes.ToListAsync();
                return Ok(listaPaciente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al obtener la lista", detalle = ex.Message });
            }
        }

        // OBTENER POR ID
        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var paciente = await dbContext.Pacientes.FirstOrDefaultAsync(e => e.Id == id);

                if (paciente == null)
                    return NotFound(new { mensaje = "Paciente no encontrado" });

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al obtener el paciente", detalle = ex.Message });
            }
        }

        // NUEVO PACIENTE
        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Paciente objeto)
        {
            try
            {
                if (objeto == null)
                    return BadRequest(new { mensaje = "El objeto paciente es inválido" });

                await dbContext.Pacientes.AddAsync(objeto);
                await dbContext.SaveChangesAsync();

                return Ok(new { mensaje = "Paciente registrado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al registrar paciente", detalle = ex.Message });
            }
        }

        // EDITAR PACIENTE
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Paciente objeto)
        {
            try
            {
                if (objeto == null || objeto.Id == 0)
                    return BadRequest(new { mensaje = "Datos inválidos" });

                var paciente = await dbContext.Pacientes.FindAsync(objeto.Id);

                if (paciente == null)
                    return NotFound(new { mensaje = "Paciente no encontrado" });

                dbContext.Entry(paciente).CurrentValues.SetValues(objeto);
                await dbContext.SaveChangesAsync();

                return Ok(new { mensaje = "Paciente actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al editar paciente", detalle = ex.Message });
            }
        }

        // ELIMINAR PACIENTE
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var paciente = await dbContext.Pacientes.FirstOrDefaultAsync(e => e.Id == id);

                if (paciente == null)
                    return NotFound(new { mensaje = "Paciente no encontrado" });

                dbContext.Pacientes.Remove(paciente);
                await dbContext.SaveChangesAsync();

                return Ok(new { mensaje = "Paciente eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al eliminar paciente", detalle = ex.Message });
            }
        }
    }
}
