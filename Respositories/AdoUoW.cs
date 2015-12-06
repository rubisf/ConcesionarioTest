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

        IRepositoryCliente rClientes;
        public IRepositoryCliente RClientes { get; set; }

        IRepositoryVehiculo rVehiculos;
        public IRepositoryVehiculo RVehiculos { get; set; }

        public AdoUoW()
        {
            this.cadCon = "Data Source=localhost; Integrated security=SSPI; Initial Catalog=Concesionario";
            this.cn = new SqlConnection(cadCon);
        }

        public void Comenzar()
        {
            this.cn.Open();
            this.t = cn.BeginTransaction();
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
