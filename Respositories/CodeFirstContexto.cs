using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class CodeFirstContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public CodeFirstContexto() : base("Data Source=ACER-LAPTOP\\SQLEXPRESS;Initial Catalog=Concesionario;User ID=root;Password=root") {}

        protected override void OnModelCreating(DbModelBuilder modelBuil)
        {
            modelBuil.Entity<Presupuesto>().ToTable("Presupuestos");
            modelBuil.Entity<Vehiculo>().ToTable("Vehiculos");
            Database.SetInitializer<CodeFirstContexto>(null);
        }
    }
}
