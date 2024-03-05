using API_institucion.Models;
using API_institucion.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_institucion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController:ControllerBase
    {
        private readonly InstitutoContext _context;
        public CursosController(InstitutoContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetCourses")]
        public IActionResult GetCourses([FromQuery] string? name)
        {
            try
            {
                var cursos = _context.Courses.ToList();

                if (name != null)
                {
                    // Filtrar por identificación si se proporciona
                    var curso = cursos.FirstOrDefault(x => x.Cour_name == name);

                    if (curso != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new
                        {
                            message = "Success",
                            data = curso
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new
                        {
                            message = "Specified course name not found",
                        });
                    }
                }
                else
                {
                    // Si no se proporciona identificación, devolver todos los estudiantes
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "Success",
                        data = cursos
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
        [Route("CreateCourse")]
        public async Task<IActionResult> CreateCourse( string nombre, string? descripcion)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Verificar si el curso ya existe
                var curso = _context.Courses.FirstOrDefault(x => x.Cour_name == nombre);

                if (curso == null)
                {
                    // El curso no existe, crear uno nuevo
                    var nuevocurso = new Cursos
                    {                      
                        Cour_name = nombre,
                        Cour_description = descripcion,                        
                    };

                    // Agregar el nuevo estudiante al contexto y guardar cambios en la base de datos
                    _context.Courses.Add(nuevocurso);
                    await _context.SaveChangesAsync();
                    // Confirmar la transacción
                    transaction.Commit();

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "CreateCourseSuccess",
                        data = nuevocurso
                    });
                }
                else
                {
                    // El CURSO ya existe, devolver un mensaje indicando que ya existe
                    return StatusCode(StatusCodes.Status409Conflict, new
                    {
                        message = "The course with the specified name already exists",
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
        [Route("DeleteCoursebyname")]
        public async Task<IActionResult> DeleteCoursebyname(string name)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Buscar el curso por nombre
                var Curso = await _context.Courses.FirstOrDefaultAsync(x => x.Cour_name == name);

                if (Curso != null)
                {                   
                    //borrar registro de la base de datos(No recomendado)
                    _context.Courses.Remove(Curso);

                    // Guardar cambios en la base de datos
                    await _context.SaveChangesAsync();
                    // Confirmar la transacción
                    transaction.Commit();

                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "DeleteCourseSuccess",
                        data = Curso
                    });
                }
                else
                {
                    // El curso no se encontró, devolver un código 404 Not Found
                    return StatusCode(StatusCodes.Status404NotFound, new
                    {
                        message = "Not deleted! Specified course not found.",
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
