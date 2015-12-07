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
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
        
        public Presupuesto(int Id, string Estado, string Importe, Vehiculo Vehiculo, Cliente Cliente)
        {
            this.Id = Id;
            this.Estado = Estado;
            this.Importe = Importe;
            this.Vehiculo = Vehiculo;
            this.Cliente = Cliente;

            this.Vehiculo.Presupuestos.Add(this);
            if(this.Cliente != null)
                this.Cliente.Presupuestos.Add(this);
        }

        public override string ToString()
        {
            string s = "";
            s = Id + " | " + Estado + " | " + Importe + "\r\n\t | " + Vehiculo + "\r\n\t | " + Cliente;
            return s;
        }

    }
}
