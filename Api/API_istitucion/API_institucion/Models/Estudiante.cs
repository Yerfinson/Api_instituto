using System;
using System.Collections.Generic;

namespace API_institucion.Models;

public partial class Estudent
{
    public int Estu_id { get; set; }

    public string? Estu_name { get; set; }

    public string? Estu_surname { get; set; }

    public int? Estu_course { get; set; }

    public int Estu_identification_number {  get; set; }

    public bool Estu_status {  get; set; }
}
