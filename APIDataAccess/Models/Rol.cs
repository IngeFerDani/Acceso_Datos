using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDataAccess.Models
{
    public class Rol
    {
        public int id_rol { get; set; }
        public string? tipo_rol { get; set; }
        public string? usuario { get; set; }
        public string? contraseña { get; set; }
    }
}