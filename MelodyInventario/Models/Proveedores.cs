using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MelodyInventario.Models
{
    public class Proveedores
    {
        public int id_proveedor { get; set; }
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        public string? nombre_empresa { get; set; }
        [Required(ErrorMessage = "El nombre del contacto es obligatorio.")]
        public string? contacto_nombre { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string? telefono { get; set; }
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? email { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string? direccion { get; set; }
    }
}