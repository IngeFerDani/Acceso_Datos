using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDataAccess.Models
{
    public class Categorias
    {
        public int id_categoria { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
    }
}