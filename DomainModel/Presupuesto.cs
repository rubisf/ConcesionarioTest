using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public partial class Presupuesto
    {

        public int Id { get; set; }
        public string Estado { get; set; }
        public double Importe { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Cliente Cliente { get; set; }
        
        public Presupuesto(int Id, string Estado, double Importe, Vehiculo Vehiculo, Cliente Cliente)
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

        public Presupuesto()
        {
            this.Vehiculo = null;
            this.Cliente = null;
        }

        public override string ToString()
        {
            string s = "";
            s = Id + " | " + Estado + " | " + Importe + "\r\n\t | " + Vehiculo + "\r\n\t | " + Cliente;
            return s;
        }
        

    }

    
}
