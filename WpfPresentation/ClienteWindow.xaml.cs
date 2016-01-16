using DomainModel;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {
        Cliente cli;
        IClienteService cs;

        public ClienteWindow(Cliente c, IClienteService cse)
        {
            this.cli = c;
            this.cs = cse;
            InitializeComponent();

            this.DataContext = cli;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.cs.ModificarTelefonoCliente(this.cli.Id,this.cli.Telefono);
        }
    }
}
