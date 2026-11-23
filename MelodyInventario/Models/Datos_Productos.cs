using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelodyInventario.Models
{
    public class Datos_Productos
    {
        public int id_producto { get; set; }
        public string? codigo_barras { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public double precio_compra { get; set; }
        public double precio_venta { get; set; }
        public double stock_actual { get; set; }
        public double stock_minimo { get; set; }
        public string? categoria { get; set; }
        public string? proveedor { get; set; }        
        public DateTime fecha_creacion { get; set; }
        
    }
}