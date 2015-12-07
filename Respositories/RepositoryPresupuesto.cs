using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModel;
using System.Data.SqlClient;

namespace Respositories
{
    public class RepositoryPresupuesto : IRepositoryPresupuesto
    {
        private SqlTransaction sqlTran;
        private SqlConnection sqlCon;
        public RepositoryPresupuesto(SqlConnection sqlCon, SqlTransaction sqlTran)
        {
            this.sqlCon = sqlCon;
            this.sqlTran = sqlTran;
        }

        private SqlCommand CreateCommand()
        {
            SqlCommand comando = sqlCon.CreateCommand();
            if (sqlTran == null)
            {
                sqlTran = sqlCon.BeginTransaction();
            }
            comando.Transaction = sqlTran;
            return comando;
        }

        public int GetId(Presupuesto p)
        {
            return p.Id;
        }

        public Presupuesto GetById(int id)
        {
            Presupuesto p = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Presupuestos WHERE id=" + id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vehiculo v = new Vehiculo(reader.GetInt32(3), "", "", 0);
                            Cliente cl = new Cliente(reader.GetInt32(4), "", "", "", false);
                            double importe = reader.GetDouble(2);
                            string estado = reader.GetString(1);
                            p = new Presupuesto(id, estado, importe + "", v, cl);
                        }
                        reader.Close();
                        RepositoryCliente rc = new RepositoryCliente(sqlCon, sqlTran);
                        p.Cliente = rc.GetById(p.Cliente.Id);
                        RepositoryVehiculo rv = new RepositoryVehiculo(sqlCon, sqlTran);
                        p.Vehiculo = rv.GetById(p.Vehiculo.Id);
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return p;
        }

        public ICollection<Presupuesto> GetPresupuestosCliente(Cliente cl)
        {
            Presupuesto c = null;
            IList<Presupuesto> ilc = new List<Presupuesto>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Presupuestos where ClienteId="+cl.Id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vehiculo v = new Vehiculo(reader.GetInt32(3), "", "", 0);
                            double importe = reader.GetDouble(2);
                            int id = reader.GetInt32(0);
                            string estado = reader.GetString(1);


                            c = new Presupuesto(id, estado, importe + "", v, cl);

                            ilc.Add(c);
                        }
                        reader.Close();
                        //Le meto los datos de vehiculos y Clientes
                        foreach (Presupuesto p in ilc)
                        {
                            RepositoryVehiculo rv = new RepositoryVehiculo(sqlCon, sqlTran);
                            p.Vehiculo = rv.GetById(p.Vehiculo.Id);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return ilc;
        }

        public ICollection<Presupuesto> GetAll()
        {
            Presupuesto c = null;
            IList<Presupuesto> ilc = new List<Presupuesto>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Presupuestos";
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vehiculo v = new Vehiculo(reader.GetInt32(3),"","",0);
                            Cliente cl = new Cliente(reader.GetInt32(4),"","","",false);
                            double importe = reader.GetDouble(2);
                            int id = reader.GetInt32(0);
                            string estado = reader.GetString(1);
                            

                            c = new Presupuesto(id, estado, importe+"", v, cl);

                            ilc.Add(c);
                        }
                        reader.Close();
                        //Le meto los datos de vehiculos y Clientes
                        foreach(Presupuesto p in ilc)
                        {
                            RepositoryCliente rc = new RepositoryCliente(sqlCon, sqlTran);
                            p.Cliente = rc.GetById(p.Cliente.Id);
                            RepositoryVehiculo rv = new RepositoryVehiculo(sqlCon, sqlTran);
                            p.Vehiculo = rv.GetById(p.Vehiculo.Id);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return ilc;
        }

        public void Add(Presupuesto t)
        {
            Presupuesto c = t;
            Vehiculo v = null;
            Cliente cl = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "INSERT into Presupuestos" +
                        "(Estado,Importe,ClienteId,VehiculoId) Values (@estado,@importe,@clienteid,@vehiculoid)";
                    sql.Parameters.AddWithValue("@estado", t.Estado);
                    sql.Parameters.AddWithValue("@importe", t.Importe);
                    sql.Parameters.AddWithValue("@clienteid", t.Cliente.Id);
                    sql.Parameters.AddWithValue("@vehiculoid", t.Vehiculo.Id);
                    sql.ExecuteNonQuery();
                    
                }
            }
        }

        public void Update(Presupuesto t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM  Presupuestos where Id=" +
                        id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Presupuesto t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM  Presupuestos where Id=" +
                        t.Id;
                    sql.ExecuteNonQuery();
                }
            }
        }
    }
}
