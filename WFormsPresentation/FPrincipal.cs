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

        public FPrincipal(IClienteService cs, IVehiculoService vService)
        {
            InitializeComponent();
            this.cService = cs;
            this.vService = vService;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AdoUoW auow = new AdoUoW();

            Application.Run(new FPrincipal(new ClienteService(auow), new VehiculoService(auow)));
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
    }
}
