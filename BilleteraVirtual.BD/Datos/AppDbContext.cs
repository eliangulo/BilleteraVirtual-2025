using BilleteraVirtual.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtual.BD.Datos
{
    public class AppDbContext : DbContext
    {
        //tablas
        public DbSet<Cuenta> Cuentas { get; set; } //Thomas
        public DbSet<Billetera> Billeteras { get; set; }//Lucas
        public DbSet<Compra> Compras { get; set; }//Jesus
        public DbSet<Deposito> Depositos { get; set; }//Jazmin
        public DbSet<Extraccion> Extracion { get; set; }//Thomas
        public DbSet<Moneda> Monedas{ get; set; }//Jazmin
        public DbSet<Transferencia> Transferencias { get; set; }//Jesus
        public DbSet<Usuarios> Usuarios { get; set; }//Lucas




        //constructor que va a crear los objetos de tipo appdbcontext
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí puedes configurar tus entidades y relaciones

        }
    }
}