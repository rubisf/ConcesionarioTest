using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Vehiculo
    {
        public int Id { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public int Potencia { get; private set; }
        public IList<Presupuesto> Presupuestos { get; private set; }


        public Vehiculo(int Id, string Modelo, string Marca, int Potencia) {
            this.Id = Id;
            this.Modelo = Modelo;
            this.Marca = Marca;
            this.Potencia = Potencia;
        }

        public void AniadePresupuesto(Presupuesto presu){
            Presupuestos.Add(presu);
        }


    }
}
