using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MelodyInventario.Models
{
    public class Producto
    {
        public int id_producto { get; set; }
        [Required(ErrorMessage = "El código de barras es obligatorio.")]
        public string? codigo_barras { get; set; }
         [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string? nombre { get; set; }
         [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string? descripcion { get; set; }
         [Range(0.01, double.MaxValue, ErrorMessage = "El precio de compra debe ser mayor a 0.")]
        public double precio_compra { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor a 0.")]
        public double precio_venta { get; set; }
          [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public double stock_actual { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public double stock_minimo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una categoría.")]
        public int? id_categoria { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un proveedor.")]
        public int? id_proveedor { get; set; }
    }
}