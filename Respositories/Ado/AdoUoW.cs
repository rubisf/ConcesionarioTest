using Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class AdoUoW : IUoW
    {
        string cadCon;
        SqlConnection cn;
        public SqlConnection Cn;
        public SqlTransaction T;
        SqlTransaction t;

        IRepositoryCliente rClientes = null;
        public IRepositoryCliente RClientes { get; set; }

        IRepositoryVehiculo rVehiculos;
        public IRepositoryVehiculo RVehiculos { get; set; }

        IRepositoryPresupuesto rPresupuesto;
        public IRepositoryPresupuesto RPresupuestos { get; set; }

        public AdoUoW()
        {
            //this.cadCon = "Data Source=localhost; Integrated security=SSPI; Initial Catalog=Concesionario;";
            this.cadCon = "server=ACER-LAPTOP\\SQLEXPRESS;Database=Concesionario;User Id=root; Password=root";
            this.cn = new SqlConnection(this.cadCon);
        }

        public void Comenzar()
        {
            try {
                this.cn.Open();
                this.t = cn.BeginTransaction();
                this.RClientes = new RepositoryCliente(cn, t);
                this.rClientes = this.RClientes;
                this.RVehiculos = new RepositoryVehiculo(cn, t);
                this.rVehiculos = this.RVehiculos;
                this.RPresupuestos = new RepositoryPresupuesto(cn, t);
                this.rPresupuesto = this.RPresupuestos;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void RollBack()
        {
            if (t != null)
                t.Rollback();
        }

        public void SaveChanges()
        {
            if (t != null)
                t.Commit();
        }

        public void Terminar()
        {
            cn.Close();
        }
    }
}
