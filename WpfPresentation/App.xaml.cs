using Respositories;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            EntityUoW auow = new EntityUoW();
            Window w1 = new MainWindow(new ClienteService(auow), new VehiculoService(auow), new PresupuestoService(auow));
            w1.Show();
        }
    }
}
