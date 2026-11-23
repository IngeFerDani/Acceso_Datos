using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MelodyInventario.Models
{
    public class Categorias
    {
        public int id_categoria { get; set; }
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string? descripcion { get; set; }
    }
}