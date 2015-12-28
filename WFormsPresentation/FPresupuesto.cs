using DomainModel;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsPresentation
{
    public partial class FPresupuesto : Form
    {
        IPresupuestoService pService;
        IClienteService cService;
        IVehiculoService vService;


        public FPresupuesto(IPresupuestoService pService, IClienteService cService, IVehiculoService vService)
        {
            InitializeComponent();
            this.pService = pService;
            this.cService = cService;
            this.vService = vService;

            ICollection<Vehiculo> clis = vService.ObtenerTodos();
            if (clis != null)
                foreach (Vehiculo cl in clis)
                {
                    this.comboVehiculo.Items.Add(cl.ToString());
                }

            ICollection<Cliente> cliss = cService.ObtenerTodos();
            if (clis != null)
                foreach (Cliente cl in cliss)
                {
                    this.comboCliente.Items.Add(cl.ToString());
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Capturo el Vehiculo
            String ve = this.comboVehiculo.SelectedItem.ToString();
            Vehiculo v = null;
            if(ve != "")
            {
                char sep = '|';
                int id = Int32.Parse(ve.Split(sep)[0].Trim());
                v = vService.Obtener(id);
            }

            //Capturo el Cliente
            String ve2 = this.comboCliente.SelectedItem.ToString();
            Cliente c = null;
            if (ve2 != "")
            {
                char sep = '|';
                int id = Int32.Parse(ve2.Split(sep)[0].Trim());
                c = cService.Obtener(id);
            }
            Presupuesto p = new Presupuesto(Int32.Parse(this.textBox1.Text), this.textBox2.Text, Double.Parse(this.textBox3.Text), v,c);

            this.pService.Añadir(p);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Presupuesto p = this.pService.Obtener(Int32.Parse(this.textBox1.Text));
            if(p != null){
                this.textBox2.Text = p.Estado;
                this.textBox3.Text = p.Importe + "";
                this.comboCliente.SelectedItem = p.Cliente.ToString();
                this.comboVehiculo.SelectedItem = p.Vehiculo.ToString();
            }
            else
            {
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.comboCliente.SelectedItem = null;
                this.comboVehiculo.SelectedItem = null;
            }
        }
    }
}
