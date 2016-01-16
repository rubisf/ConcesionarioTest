using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DomainModel;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Respositories
{
    public class ERepositoryCliente : IRepositoryCliente
    {
        private CodeFirstContexto contexto;
        private bool disposed = false;
        public ERepositoryCliente(CodeFirstContexto contexto)
        {
            this.contexto = contexto;
        }



        public int GetId(Cliente cli)
        {
            return cli.Id;
        }

        public Cliente GetById(int id)
        {
            Cliente c = null;
            using (var dbcxtransaction = contexto.Database.BeginTransaction())
            {
                c = contexto.Clientes.Find(id);
            }
            return c;
        }

        public ICollection<Cliente> GetAll()
        {
            ICollection<Cliente> clis = null;

            clis = this.contexto.Clientes.ToList();
                
         
            return clis;
        }

        public void Add(Cliente t)
        {
            using (var dbcxtransaction = contexto.Database.BeginTransaction()) { 
                contexto.Clientes.Add(t);
            }
        }

        public void Update(Cliente t)
        {
            using (var dbcxtransaction = contexto.Database.BeginTransaction())
            {
                contexto.Entry(t).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Cliente c = GetById(id);
            using (var dbcxtransaction = contexto.Database.BeginTransaction())
            {
                Delete(c);
            }
        }

        public void Delete(Cliente t)
        {
            using (var dbcxtransaction = contexto.Database.BeginTransaction())
            {
                Cliente stub = new Cliente();
                stub.Id = t.Id;
                contexto.Clientes.Remove(stub);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
