using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nombre { get; set;  }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public bool Vip { get; set; }
        public virtual ICollection<Presupuesto> Presupuestos  { get; set; }

        

        public Cliente(int Id, string Nombre, string Apellidos, string Telefono, bool Vip){
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Telefono = Telefono;
            this.Vip = Vip;
            this.Presupuestos = new List<Presupuesto>();
        }

        public Cliente()
        {
            this.Presupuestos = new List<Presupuesto>();
        }

        public void AniadePresupuesto(Presupuesto presu)
        {
            Presupuestos.Add(presu);
        }

        public override String ToString()
        {
            string cli = Id + " | " + Nombre + " | " + Apellidos + " | " + Telefono + " | " + Vip;
            if(this.Presupuestos != null)
            foreach(Presupuesto p in this.Presupuestos)
            {
                cli = cli + "\r\n\t" + p.Id + " | " + p.Estado + " | " + p.Importe;
            }

            return   cli;

        }

    }
}
