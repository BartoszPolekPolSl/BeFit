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

namespace BeFit.View
{
    /// <summary>
    /// Logika interakcji dla klasy BeFit.xaml
    /// </summary>
    using ViewModel;
    using Model;
    public partial class BeFitWindow : Window
    {

        private BeFitViewModel BeFitVM;
        public BeFitWindow(Model model)
        {
            BeFitVM = new BeFitViewModel(model);
            InitializeComponent();
            DataContext = BeFitVM;
            BeFitVM.UnselectEatenProductsIndex += unselectListBoxIndex;
        }

        private void unselectListBoxIndex()
        {
            listboxEatenProducts.SelectedIndex = -1;
        }
    }
}
