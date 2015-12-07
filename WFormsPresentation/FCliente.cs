using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Respositories;
using DomainModel;

namespace WFormsPresentation
{
    public partial class FCliente : Form
    {
        IClienteService cs;

        public FCliente(IClienteService cs)
        {
            InitializeComponent();
            this.cs = cs;
        }

        private void FCliente_Load(object sender, EventArgs e)
        {

        }

        private void labelId_TextChanged(object sender, EventArgs e)
        {
            int i = -1;
            try {
                i = Int32.Parse(this.labelId.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error convirtiendo el Id");
            }


            Cliente c = cs.Obtener(i);
            if(c != null)
            {
                this.labelNombre.Text = c.Nombre;
                this.labelApellidos.Text = c.Apellidos;
                this.labelTelefono.Text = c.Telefono;
                this.checkBox1.Checked = c.Vip;
            }
            else
            {
                this.labelNombre.Text = "";
                this.labelApellidos.Text = "";
                this.labelTelefono.Text = "";
                this.checkBox1.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cs.ModificarTelefonoCliente(Int32.Parse(this.labelId.Text), this.labelTelefono.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(Int32.Parse(this.labelId.Text), this.labelNombre.Text, this.labelApellidos.Text, this.labelTelefono.Text, this.checkBox1.Checked);
            cs.Eliminar(c);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(Int32.Parse(this.labelId.Text), this.labelNombre.Text, this.labelApellidos.Text, this.labelTelefono.Text, this.checkBox1.Checked);
            cs.Añadir(c);
        }
    }
}
