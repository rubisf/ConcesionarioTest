using DomainModel;
using Respositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IClienteService cService;
        IVehiculoService vService;
        IPresupuestoService pService;

        public MainWindow(ClienteService cs,VehiculoService vs, PresupuestoService ps)
        {
            this.cService = cs;
            this.vService = vs;
            this.pService = ps;
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            LClienteWindow cw = new LClienteWindow(this.cService);
            cw.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ClienteWindow cw = new ClienteWindow(this.cService.Obtener(1),this.cService);
            cw.Show();
        }
    }
}
