﻿using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IVehiculoService : IService<Vehiculo>
    {
        void AñadirPresupuestoVehiculo(Vehiculo v, Presupuesto p);
        ICollection<Presupuesto> PresupuestosPorVehiculo(Vehiculo v);
    }
}
