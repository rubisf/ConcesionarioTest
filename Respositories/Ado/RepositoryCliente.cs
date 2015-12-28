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
    public class RepositoryCliente : IRepositoryCliente
    {
        private SqlTransaction sqlTran;
        private SqlConnection sqlCon;
        public RepositoryCliente(SqlConnection sqlCon, SqlTransaction sqlTran)
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

        public void Add(Cliente t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "INSERT into Clientes" +
                        "(Nombre,Apellidos,Telefono,VIP) Values (@nombre,@apellidos,@telefono,@vip)";
                    sql.Parameters.AddWithValue("@nombre", t.Nombre);
                    sql.Parameters.AddWithValue("@apellidos", t.Apellidos);
                    sql.Parameters.AddWithValue("@telefono", t.Telefono);
                    sql.Parameters.AddWithValue("@vip", t.Vip);

                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Cliente t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM  Clientes where Id=" +
                        t.Id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM  Clientes where Id=" +
                        id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public ICollection<Cliente> GetAll()
        {
            IList<Cliente> ilc = new List<Cliente>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Clientes";
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Cliente c = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4));
                            ilc.Add(c);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();

                    foreach(Cliente c in ilc)
                    {
                        RepositoryPresupuesto rp = new RepositoryPresupuesto(this.sqlCon, this.sqlTran);
                        ICollection<Presupuesto> ilp = rp.GetPresupuestosCliente(c);
                        c.Presupuestos = ilp.Cast<Presupuesto>().ToList(); ;
                    }
                }
            }
            return ilc;
        }

        public Cliente GetById(int id)
        {
            Cliente c = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Clientes WHERE id="+id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            c = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    RepositoryPresupuesto rp = new RepositoryPresupuesto(this.sqlCon,this.sqlTran);
                    ICollection<Presupuesto> ilp = rp.GetPresupuestosCliente(c);
                    c.Presupuestos = ilp.Cast<Presupuesto>().ToList();
                }
            }
            return c;
        }

        public int GetId(Cliente cli)
        {
            return cli.Id;
        }

        public void Update(Cliente t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "UPDATE Clientes SET" +
                        " Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono ,VIP = @vip WHERE Id = "+t.Id;
                    sql.Parameters.AddWithValue("@nombre", t.Nombre);
                    sql.Parameters.AddWithValue("@apellidos", t.Apellidos);
                    sql.Parameters.AddWithValue("@telefono", t.Telefono);
                    sql.Parameters.AddWithValue("@vip", t.Vip);

                    sql.ExecuteNonQuery();
                }
            }
        }
    }
}
