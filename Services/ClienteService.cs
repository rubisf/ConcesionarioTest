using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Contracts;

namespace Services
{
    public class ClienteService : IClienteService
    {
        IUoW uow;

        public ClienteService(IUoW uow)
        {
            this.uow = uow;
        }
        public ICollection<Cliente> ObtenerTodos()
        {
                ICollection<Cliente> c = null;
                try
                {
                    uow.Comenzar();
                    c = uow.RClientes.GetAll();
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

        public void Añadir(Cliente t)
        {
            try
            {
                uow.Comenzar();
                uow.RClientes.Add(t);
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

        public void AñadirPresupuestoCliente(Cliente c, Presupuesto p)
        {
            try
            {
                uow.Comenzar();
                c.AniadePresupuesto(p);
                uow.RClientes.Update(c);
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

        public void Eliminar(Cliente t)
        {
            try
            {
                uow.Comenzar();
                uow.RClientes.Delete(t);
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

        public void ModificarTelefonoCliente(int id, string telefono)
        {
            try
            {
                uow.Comenzar();
                Cliente c = uow.RClientes.GetById(id);
                c.Telefono = telefono;
                uow.RClientes.Update(c);
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

        public Cliente Obtener(int id)
        {
            Cliente c = null;
            try
            {
                uow.Comenzar();
                c = uow.RClientes.GetById(id);
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

        public ICollection<Presupuesto> PresupuestosPorCliente(Cliente c)
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
