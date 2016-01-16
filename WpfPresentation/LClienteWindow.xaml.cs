using DomainModel;
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
using System.Windows.Shapes;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for LClienteWindow.xaml
    /// </summary>
    public partial class LClienteWindow : Window
    {
        IClienteService cService;
        public ICollection<Cliente> clientes { get; set; }
        
        public LClienteWindow(IClienteService ics)
        {
            this.cService = ics;
            //Cargo el listado de Clientes
            this.clientes = this.cService.ObtenerTodos();
            InitializeComponent();
            this.DataContext = this;




        }

       

        private void PlaceholdersListBox_OnPreviewMouseDown(object sender, RoutedEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                Cliente cl = (Cliente)item.DataContext;
                ClienteWindow c = new ClienteWindow(cl, this.cService);
                c.Show();
                
            }
            
        }
    }
}
