using System.ComponentModel.DataAnnotations.Schema;

namespace API_institucion.Models
{
    [Table("tbl_courses")] // Nombre de la tabla en la base de datos
    public class Cursos
    {
        public int Cour_id { get; set; }

        public string? Cour_name { get; set; }

        public string? Cour_description { get; set; }
    }
}
