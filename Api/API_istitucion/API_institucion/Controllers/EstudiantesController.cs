using API_institucion.Models;
using API_institucion.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_institucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudentsController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public EstudentsController(InstitutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetEstudents")]
        public IActionResult GetEstudents([FromQuery] int identificacion)
        {
            try
            {
                var estudiantes = _context.Estudents.ToList();

                if (identificacion > 0)
                {
                    // Filtrar por identificación si se proporciona
                    var estudianteById = estudiantes.FirstOrDefault(x => x.Estu_identification_number == identificacion);

                    if (estudianteById != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            message = "Success",
                            data = estudianteById
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new
                        {
                            message = "Specified student identification not found",
                        });
                    }
                }
                else
                {
                    // Si no se proporciona identificación, devolver todos los estudiantes
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "Success",
                        data = estudiantes
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Route("CreateStudent")]
        public async Task<IActionResult> CreateEstudent(int documento, string nombre, string apellido)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Verificar si el estudiante ya existe
                var estudianteExistente = await _context.Estudents.FirstOrDefaultAsync(x => x.Estu_identification_number == documento);

                if (estudianteExistente == null)
                {
                    // El estudiante no existe, crear uno nuevo
                    var nuevoEstudiante = new Estudent
                    {
                        Estu_identification_number = documento,
                        Estu_name = nombre,
                        Estu_surname = apellido,
                        Estu_status = true
                    };

                    // Agregar el nuevo estudiante al contexto y guardar cambios en la base de datos
                    _context.Estudents.Add(nuevoEstudiante);
                    await _context.SaveChangesAsync();
                    // Confirmar la transacción
                    transaction.Commit();

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "CreateStudentSuccess",
                        data = nuevoEstudiante
                    });
                }
                else
                {
                    // El estudiante ya existe, devolver un mensaje indicando que ya existe
                    return StatusCode(StatusCodes.Status409Conflict, new
                    {
                        message = "The student with the specified document already exists",
                    });
                }
            }
            catch (Exception ex)
            {
                // Revertir la transacción en caso de error
                transaction.Rollback();

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpDelete]
        [Route("DeleteEstudentbyidentification")]
        public async Task<IActionResult> DeletEstudentbyid(int identificacion)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Buscar el estudiante por identificación
                var estudiante = await _context.Estudents.FirstOrDefaultAsync(x => x.Estu_identification_number == identificacion);

                if (estudiante != null)
                {
                    // Actualizar el estado del estudiante a inactivo
                    estudiante.Estu_status = false;
                    _context.Estudents.Update(estudiante);

                    // Guardar cambios en la base de datos
                    await _context.SaveChangesAsync();
                    // Confirmar la transacción
                    transaction.Commit();

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "DeleteStudentSuccess",
                        data = estudiante
                    });
                }
                else
                {
                    // El estudiante no se encontró, devolver un código 404 Not Found
                    return StatusCode(StatusCodes.Status404NotFound, new
                    {
                        message = "Not deleted! Specified student not found.",
                    });
                }
            }
            catch (Exception ex)
            {
                // Revertir la transacción en caso de error
                transaction.Rollback();

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }

        [HttpPut]
        [Route("UpdateEstudent")]
        public async Task<IActionResult> UpdateEstudent(int identificacion, string? nombre, string? apellido)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Verificar que al menos uno de los campos (nombre o apellido) se proporcione
                if (nombre == null && apellido == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        message = "Update failed! Provide at least one field (nombre or apellido) for the update.",
                    });
                }

                // Buscar el estudiante por identificación
                var estudiante = await _context.Estudents.FirstOrDefaultAsync(x => x.Estu_identification_number == identificacion);

                if (estudiante != null)
                {
                    // Actualizar los datos del estudiante si se proporcionan
                    if (nombre != null)
                    {
                        estudiante.Estu_name = nombre;
                    }

                    if (apellido != null)
                    {
                        estudiante.Estu_surname = apellido;
                    }

                    // Guardar cambios en la base de datos
                    await _context.SaveChangesAsync();
                    // Confirmar la transacción
                    transaction.Commit();
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "UpdateEstudentSuccess",
                        data = estudiante
                    });
                }
                else
                {
                    // El estudiante no se encontró, devolver un código 404 Not Found
                    return StatusCode(StatusCodes.Status404NotFound, new
                    {
                        message = "Update failed! The specified student record does not exist",
                    });
                }
            }
            catch (Exception ex)
            {
                // Revertir la transacción en caso de error
                transaction.Rollback();

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message,
                });
            }
        }
    }
}
