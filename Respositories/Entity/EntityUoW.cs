using Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class EntityUoW : IUoW
    {
        CodeFirstContexto Contexto;

        IRepositoryCliente rClientes = null;
        public IRepositoryCliente RClientes { get; set; }

        IRepositoryVehiculo rVehiculos;
        public IRepositoryVehiculo RVehiculos { get; set; }

        IRepositoryPresupuesto rPresupuesto;
        public IRepositoryPresupuesto RPresupuestos { get; set; }

        public EntityUoW()
        {
            this.Contexto = new CodeFirstContexto();
            this.Contexto.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public void Comenzar()
        {
            try {
                this.RClientes = new ERepositoryCliente(this.Contexto);
                this.rClientes = this.RClientes;
                this.RVehiculos = new ERepositoryVehiculo(this.Contexto);
                this.rVehiculos = this.RVehiculos;
                this.RPresupuestos = new ERepositoryPresupuesto(this.Contexto);
                this.rPresupuesto = this.RPresupuestos;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void RollBack()
        {
            try {
                if (Contexto.Database != null)
                    Contexto.Database.CurrentTransaction.Rollback();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveChanges()
        {
            Contexto.SaveChanges();
        }

        public void Terminar()
        {
            //Contexto.Dispose();
        }
    }
}
