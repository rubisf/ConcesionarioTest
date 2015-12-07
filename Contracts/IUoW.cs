using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUoW
    {
        IRepositoryCliente RClientes { get; }
        IRepositoryVehiculo RVehiculos { get; }
        IRepositoryPresupuesto RPresupuestos { get; }

        void Comenzar();
        void Terminar();
        void SaveChanges();
        void RollBack();
    }
}
