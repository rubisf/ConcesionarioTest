using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Contracts;

namespace Services
{
    public class VehiculoService : IVehiculoService
    {
        IUoW uow;

        public VehiculoService(IUoW uow)
        {
            this.uow = uow;
        }
        public ICollection<Vehiculo> ObtenerTodos()
        {
                ICollection<Vehiculo> c = null;
                try
                {
                    uow.Comenzar();
                    c = uow.RVehiculos.GetAll();
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

        public void Añadir(Vehiculo t)
        {
            try
            {
                uow.Comenzar();
                uow.RVehiculos.Add(t);
                uow.SaveChanges();
            }
            catch(Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }

        public void AñadirPresupuestoVehiculo(Vehiculo c, Presupuesto p)
        {
            try
            {
                uow.Comenzar();
                c.AniadePresupuesto(p);
                uow.RVehiculos.Update(c);
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

        public void Eliminar(Vehiculo t)
        {
            try
            {
                uow.Comenzar();
                uow.RVehiculos.Delete(t);
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

        public Vehiculo Obtener(int id)
        {
            Vehiculo c = null;
            try
            {
                uow.Comenzar();
                c = uow.RVehiculos.GetById(id);
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

        public ICollection<Presupuesto> PresupuestosPorVehiculo(Vehiculo c)
        {
            ICollection<Presupuesto> pr = null;
            try
            {
                uow.Comenzar();
                pr = c.Presupuestos;
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

            return pr;
        }
    }
}
