using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Contracts;

namespace Services
{
    public class PresupuestoService : IPresupuestoService
    {
        IUoW uow;

        public PresupuestoService(IUoW uow)
        {
            this.uow = uow;
        }
        public ICollection<Presupuesto> ObtenerTodos()
        {
            ICollection<Presupuesto> c = null;
            try
            {
                uow.Comenzar();
                c = uow.RPresupuestos.GetAll();
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
            return c;
        }

        public void Añadir(Presupuesto t)
        {
            try
            {
                uow.Comenzar();
                uow.RPresupuestos.Add(t);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }
        

        public void Eliminar(Presupuesto t)
        {
            try
            {
                uow.Comenzar();
                uow.RPresupuestos.Delete(t);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }


        public Presupuesto Obtener(int id)
        {
            Presupuesto c = null;
            try
            {
                uow.Comenzar();
                c = uow.RPresupuestos.GetById(id);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
            return c;
        }

    }
}
