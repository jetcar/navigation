using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication2.ViewModels;
using WpfApplication2.utils;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IMyRegionManager RegionManager = new MyRegionManager();

        public static IMediator MessageMediator = new MyMessageMediator();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = RegionManager.FindWindowByViewModel<MainViewModel>();
            window.Show();

        }
    }
}
