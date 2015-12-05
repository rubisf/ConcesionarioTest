using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Presupuesto
    {

        public int Id { get; private set; }
        public string Estado { get; private set; }
        public string Importe { get; private set; }
        public Vehiculo Vehiculo { get; private set; }
        public Cliente Cliente { get; private set; }
        
        public Presupuesto(int Id, string Estado, string Importe, Vehiculo Vehiculo, Cliente Cliente)
        {
            this.Id = Id;
            this.Estado = Estado;
            this.Importe = Importe;
            this.Vehiculo = Vehiculo;
            this.Cliente = Cliente;

            this.Vehiculo.Presupuestos.Add(this);
            this.Cliente.Presupuestos.Add(this);
        }
    }
}
