using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication2.utils;

namespace WpfApplication2.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public override void OnNavigationCompleted()
        {
            MyRegionManager.NavigateUsingViewModel<UserControl1ViewModel>(RegionNames.ContentRegion);
            base.OnNavigationCompleted();
        }
    }
}
