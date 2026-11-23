using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIDataAccess.Data;
using APIDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDataAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataAccessController : ControllerBase
    {
        private readonly DataAccessDbContext context;
        public DataAccessController(DataAccessDbContext context)
        {
            this.context = context;
        }
        //leeer las categorias
        [HttpGet("categorias")]
        public async Task<ActionResult<List<Categorias>>> GetBrands()
        {
            return await context.categorias.ToListAsync();
        }
        [HttpGet("productos")]
        public async Task<ActionResult<List<Productos>>> GetProducts()
        {
            return await context.productos.ToListAsync();
        }
        //leer los proveedores
        [HttpGet("proveedores")]
        public async Task<ActionResult<List<Proveedores>>> GetSuppliers()
        {
            return await context.proveedores.ToListAsync();
        }
        //leer los productos
        [HttpGet("productosdatos")]
        public async Task<ActionResult<List<Productos>>> GetProductsDates()
        {
            var resultado = await (from p in context.productos
                                   join c in context.categorias on p.id_categoria equals c.id_categoria
                                   join pr in context.proveedores on p.id_proveedor equals pr.id_proveedor
                                   select new Datos_productos
                                   {
                                       codigo_barras = p.codigo_barras,
                                       nombre = p.nombre,
                                       descripcion = p.descripcion,
                                       categoria = c.nombre,
                                       proveedor = pr.nombre_empresa,
                                       precio_compra = p.precio_compra,
                                       precio_venta = p.precio_venta,
                                       stock_actual = p.stock_actual,
                                       stock_minimo = p.stock_minimo,
                                       fecha_creacion = p.fecha_creacion
                                   })
                                      .ToListAsync();

            return Ok(resultado);
        }
        //insertar categoria nueva
        [HttpPost("categorias")]
        public async Task<ActionResult<Categorias>> PostCategoria(Categorias categoria)
        {
            context.categorias.Add(categoria);
            await context.SaveChangesAsync();

            return Ok(categoria);
        }
        //insertar proveedor nuevo
        [HttpPost("proveedores")]
        public async Task<ActionResult<Proveedores>> PostProveedor(Proveedores proveedor)
        {
            context.proveedores.Add(proveedor);

            await context.SaveChangesAsync();

            return Ok(proveedor);
        }
        //insertar producto nuevo
        [HttpPost("productos")]
        public async Task<ActionResult<Productos>> PostProducto(Productos producto)
        {
            context.productos.Add(producto);

            await context.SaveChangesAsync();

            return Ok(producto);
        }
        [HttpPost("movimiento")]
        public async Task<IActionResult> RegistrarMovimiento(MovimientoRequest movimiento)
        {
            var producto = await context.productos
                .FirstOrDefaultAsync(p => p.id_producto == movimiento.idProducto);

            if (producto == null)
                return NotFound("Producto no encontrado.");

            if (movimiento.cantidad <= 0)
                return BadRequest("La cantidad debe ser mayor a 0.");

            switch (movimiento.tipoMovimiento.ToLower())
            {
                case "entrada":
                    producto.stock_actual += movimiento.cantidad;
                    break;

                case "salida":
                    if (producto.stock_actual < movimiento.cantidad)
                        return BadRequest("No hay suficiente stock.");

                    producto.stock_actual -= movimiento.cantidad;
                    break;

                case "ajuste":
                    producto.stock_actual = movimiento.cantidad;
                    break;

                default:
                    return BadRequest("Tipo de movimiento no válido.");
            }

            await context.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpPut("updateproduct/{id}")]
        public async Task<IActionResult> Updateproduct(int id, Productos product)
        {
            var producto = await context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound(new { error = "Producto no encontrado" });
            }
            producto.codigo_barras = product.codigo_barras;
            producto.nombre = product.nombre;
            producto.descripcion = product.descripcion;
            producto.precio_compra = product.precio_compra;
            producto.precio_venta = product.precio_venta;
            producto.stock_actual = product.stock_actual;
            producto.stock_minimo = product.stock_minimo;
            producto.id_categoria = product.id_categoria;
            producto.id_proveedor = product.id_proveedor;
            await context.SaveChangesAsync();
            return Ok(producto);
        }
        [HttpPut("updatecategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Categorias category)
        {
            var categoria = await context.categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound(new { error = "Categoría no encontrada" });
            }
            categoria.nombre = category.nombre;
            categoria.descripcion = category.descripcion;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
        [HttpPut("updateproveedor/{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, Proveedores proveedor)
        {
            var proveedorr = await context.proveedores.FindAsync(id);

            if (proveedorr == null)
            {
                return NotFound(new { error = "Proveedor no encontrado" });
            }
            proveedorr.nombre_empresa = proveedor.nombre_empresa;
            proveedorr.contacto_nombre = proveedor.contacto_nombre;
            proveedorr.telefono = proveedor.telefono;
            proveedorr.email = proveedor.email;
            proveedorr.direccion = proveedor.direccion;
            await context.SaveChangesAsync();
            return Ok(proveedorr);
        }

        [HttpGet("producto/{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound(new { error = "Producto no encontrado" });
            }

            return Ok(producto);
        }
        [HttpDelete("deleteproduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var producto = await context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound(new { error = "Producto no encontrado" });
            }

            context.productos.Remove(producto);

            await context.SaveChangesAsync();

            return Ok(new { mensaje = "Producto eliminado correctamente" });
        }
        [HttpDelete("deletecategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoria = await context.categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound(new { error = "Categoría no encontrada" });
            }

            context.categorias.Remove(categoria);

            await context.SaveChangesAsync();

            return Ok(new { mensaje = "Categoría eliminada correctamente" });
        }
        [HttpDelete("deleteproveedor/{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await context.proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound(new { error = "Proveedor no encontrado" });
            }

            context.proveedores.Remove(proveedor);

            await context.SaveChangesAsync();

            return Ok(new { mensaje = "Proveedor eliminado correctamente" });
        }
        [HttpPost("movimientoVendedor")]
        public async Task<IActionResult> RegistrarMovimientoVendedor(MovimientoRequestVendedor movimiento)
        {
            // Buscar el producto por ID
            var producto = await context.productos
                .FirstOrDefaultAsync(p => p.id_producto == movimiento.idProducto);

            // Si no existe
            if (producto == null)
            {
                return NotFound("El producto no existe");
            }

            // Comprobar que haya suficiente stock
            if (producto.stock_actual < movimiento.cantidad)
            {
                return BadRequest("No hay suficiente stock");
            }

            // RESTAR la cantidad al stock
            producto.stock_actual -= movimiento.cantidad;

            // Guardar cambios
            await context.SaveChangesAsync();

            return Ok("Salida registrada correctamente");
        }
        [HttpPost("movimientoAlmacenista")]
        public async Task<IActionResult> RegistrarMovimientoAlmacenista(MovimientoRequestAlmacenista movimiento)
        {
            // Buscar el producto por ID
            var producto = await context.productos
                .FirstOrDefaultAsync(p => p.id_producto == movimiento.idProducto);

            // Si no existe
            if (producto == null)
            {
                return NotFound("El producto no existe");
            }
            // SUMAR la cantidad al stock
            producto.stock_actual += movimiento.cantidad;

            // Guardar cambios
            await context.SaveChangesAsync();

            return Ok("Entrada registrada correctamente");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var usuario = await context.rol
                .FirstOrDefaultAsync(u =>
                    u.usuario == login.usuario &&
                    u.contraseña == login.contraseña);

            if (usuario == null)
            {
                return Unauthorized(new LoginResponse
                {
                    exitoso = false,
                    mensaje = "Usuario o contraseña incorrectos"
                });
            }

            return Ok(new LoginResponse
            {
                exitoso = true,
                mensaje = "Login correcto",
                rol = usuario.tipo_rol ?? ""
            });
        }
        [HttpGet("productos-alerta-stock")]
        public async Task<ActionResult> GetProductosAlertaStock()
        {
            var productos = await context.productos
                .Where(p => p.stock_actual <= p.stock_minimo)
                .Select(p => new
                {
                    p.id_producto,
                    p.nombre,
                    p.stock_actual,
                    p.stock_minimo,
                    estado = p.stock_actual == 0
                        ? "Sin stock"
                        : "Bajo stock"
                })
                .ToListAsync();

            return Ok(productos);
        }
        public class MovimientoRequest
        {
            public int idProducto { get; set; }
            public string tipoMovimiento { get; set; } = "";
            public int cantidad { get; set; }
        }
        public class MovimientoRequestVendedor
        {
            public int idProducto { get; set; }
            public int cantidad { get; set; }
        }
        public class MovimientoRequestAlmacenista
        {
            public int idProducto { get; set; }
            public int cantidad { get; set; }
        }
        public class LoginRequest
        {
            public string usuario { get; set; } = "";
            public string contraseña { get; set; } = "";
        }
        public class LoginResponse
        {
            public bool exitoso { get; set; }
            public string mensaje { get; set; } = "";
            public string rol { get; set; } = "";
        }
    }
}