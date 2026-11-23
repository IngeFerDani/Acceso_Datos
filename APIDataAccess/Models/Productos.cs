using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIDataAccess.Models
{
    public class Productos
    {
        public int id_producto { get; set; }
        public string? codigo_barras { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public double precio_compra { get; set; }
        public double precio_venta { get; set; }
        public double stock_actual { get; set; }
        public double stock_minimo { get; set; }
        public int? id_categoria { get; set; }
        [ForeignKey("id_categoria")]
        public Categorias? Categoria { get; set; }
        public int? id_proveedor { get; set; }
        [ForeignKey("id_proveedor")]
        public Proveedores? Proveedor { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}