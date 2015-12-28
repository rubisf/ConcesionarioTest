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
    public partial class FPrincipal : Form
    {

        IClienteService cService;
        IVehiculoService vService;
        IPresupuestoService pService;

        public FPrincipal(IClienteService cs, IVehiculoService vService, IPresupuestoService pService)
        {
            InitializeComponent();
            this.cService = cs;
            this.vService = vService;
            this.pService = pService;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EntityUoW auow = new EntityUoW();

            Application.Run(new FPrincipal(new ClienteService(auow), new VehiculoService(auow), new PresupuestoService(auow)));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICollection<Cliente> clis = cService.ObtenerTodos();
            Console.WriteLine("** Listado de Clientes **");
            if(clis != null)
                foreach (Cliente cl in clis)
                {
                    Console.WriteLine(cl);
                }
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cli = new FCliente(this.cService);
            cli.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ICollection<Presupuesto> clis = pService.ObtenerTodos();
            Console.WriteLine("** Listado de Presupuestos **");
            if (clis != null)
                foreach (Presupuesto cl in clis)
                {
                    Console.WriteLine(cl);
                }
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cli = new FPresupuesto(this.pService,this.cService,this.vService);
            cli.Show();
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ICollection<Vehiculo> clis = vService.ObtenerTodos();
            Console.WriteLine("** Listado de Vehiculos **");
            //if (clis != null)
            foreach (Vehiculo cl in clis)
            {
                Console.WriteLine(cl);
            }
        }
    }
}
