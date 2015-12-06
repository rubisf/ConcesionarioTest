using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IClienteService : IService<Cliente>
    {
        void ModificarTelefonoCliente(int id, string telefono);
        void AñadirPresupuestoCliente(Cliente c, Presupuesto p);
        ICollection<Presupuesto> PresupuestosPorCliente(Cliente c);
    }
}
