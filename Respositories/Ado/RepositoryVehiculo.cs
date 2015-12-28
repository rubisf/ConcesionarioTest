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
    public class RepositoryVehiculo : IRepositoryVehiculo
    {
        private SqlTransaction sqlTran;
        private SqlConnection sqlCon;
        public RepositoryVehiculo(SqlConnection sqlCon, SqlTransaction sqlTran)
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

        public int GetId(Vehiculo cli)
        {
            return cli.Id;
        }

        public Vehiculo GetById(int id)
        {
            Vehiculo c = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Vehiculos WHERE id=" + id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            c = new Vehiculo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
                return c;
            }
        }

        public ICollection<Vehiculo> GetAll()
        {
            IList<Vehiculo> ilc = new List<Vehiculo>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Vehiculos";
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vehiculo c = new Vehiculo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                            ilc.Add(c);
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

        public void Add(Vehiculo t)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehiculo t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vehiculo t)
        {
            throw new NotImplementedException();
        }

    }
}
