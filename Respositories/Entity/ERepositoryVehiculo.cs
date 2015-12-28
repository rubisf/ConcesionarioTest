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
    public class ERepositoryVehiculo : IRepositoryVehiculo
    {
        private CodeFirstContexto contexto;
        private bool disposed = false;
        public ERepositoryVehiculo(CodeFirstContexto contexto)
        {
            this.contexto = contexto;
        }



        public int GetId(Vehiculo cli)
        {
            return cli.Id;
        }

        public Vehiculo GetById(int id)
        {
            return contexto.Vehiculos.Find(id);
        }

        public ICollection<Vehiculo> GetAll()
        {
            return contexto.Vehiculos.ToList();
        }

        public void Add(Vehiculo t)
        {
            contexto.Vehiculos.Add(t);
        }

        public void Update(Vehiculo t)
        {
            contexto.Entry(t).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public void Delete(Vehiculo t)
        {
            contexto.Vehiculos.Remove(t);
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
