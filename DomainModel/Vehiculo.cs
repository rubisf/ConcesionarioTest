using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Potencia { get; set; }
        public virtual ICollection<Presupuesto> Presupuestos { get; set; }


        public Vehiculo(int Id, string Modelo, string Marca, int Potencia) {
            this.Id = Id;
            this.Modelo = Modelo;
            this.Marca = Marca;
            this.Potencia = Potencia;
            this.Presupuestos = new List<Presupuesto>();

        }

        public Vehiculo()
        {
            this.Presupuestos = new List<Presupuesto>();
        }

        public void AniadePresupuesto(Presupuesto presu){
            Presupuestos.Add(presu);
        }

        public override string ToString()
        {
            return this.Id + " | "+Modelo + " | " + Marca + " | " + Potencia;
        }


    }
}
