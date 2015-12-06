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
                    sql.Parameters.AddWithValue("@nombre", t.Apellidos);
                    sql.Parameters.AddWithValue("@nombre", t.Telefono);
                    sql.Parameters.AddWithValue("@nombre", t.Vip);

                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Cliente t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
                            Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                                reader.GetString(1));
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

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetId(Cliente cli)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente t)
        {
            throw new NotImplementedException();
        }
    }
}
