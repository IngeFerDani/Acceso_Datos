using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIDataAccess.Models;

namespace APIDataAccess.Data
{
    public class DataAccessDbContext : DbContext
    {
        public DataAccessDbContext(DbContextOptions<DataAccessDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Rol> rol { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>().HasKey(c => c.id_categoria);
            modelBuilder.Entity<Proveedores>().HasKey(p => p.id_proveedor);
            modelBuilder.Entity<Productos>().HasKey(pr => pr.id_producto);
            modelBuilder.Entity<Rol>().HasKey(r => r.id_rol);
        }
    }
}