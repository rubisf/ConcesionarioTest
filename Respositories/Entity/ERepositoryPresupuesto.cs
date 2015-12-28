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
    public class ERepositoryPresupuesto : IRepositoryPresupuesto
    {
        private CodeFirstContexto contexto;
        private bool disposed = false;
        public ERepositoryPresupuesto(CodeFirstContexto contexto)
        {
            this.contexto = contexto;
        }



        public int GetId(Presupuesto cli)
        {
            return cli.Id;
        }

        public Presupuesto GetById(int id)
        {
            Presupuesto p;
            p = contexto.Presupuestos.Find(id);
            return p;
        }

        public ICollection<Presupuesto> GetAll()
        {
            return contexto.Presupuestos.ToList();
        }

        public void Add(Presupuesto t)
        {
            contexto.Presupuestos.Add(t);
        }

        public void Update(Presupuesto t)
        {
            contexto.Entry(t).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(Presupuesto t)
        {
            contexto.Presupuestos.Remove(t);
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
