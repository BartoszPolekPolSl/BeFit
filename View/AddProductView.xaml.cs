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

namespace BeFit.View
{
    /// <summary>
    /// Logika interakcji dla klasy AddProductView.xaml
    /// </summary>
    using ViewModel;
    using Model;
    public partial class AddProductView : UserControl
    {

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        public AddProductView(BeFitViewModel befitVM)
        {
            InitializeComponent();
            DataContext = befitVM;
            BindingOperations.SetBinding(txtBoxName, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentProductName)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxProteins, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentProteins)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxFats, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentFats)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxCarbohydrates, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentCarbohydrates)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxKcal, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentKcal)), Source = DataContext });
            BindingOperations.SetBinding(txtBoxWeight, TextBox.TextProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.CurrentWeight)), Source = DataContext });
            BindingOperations.SetBinding(btnAddEatenProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.AddEatenProduct)), Source = DataContext });
            BindingOperations.SetBinding(btnRemoveEatenProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.RemoveEatenProduct)), Source = DataContext });
            BindingOperations.SetBinding(btnEditFavoriteProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.EditFavoriteProduct)), Source = DataContext});
            BindingOperations.SetBinding(listBoxFavoriteProducts, ListBox.ItemsSourceProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.FavoriteProducts)), Source = DataContext });
            BindingOperations.SetBinding(btnAddFavoriteProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.AddFavoriteProduct)), Source = DataContext });
            BindingOperations.SetBinding(btnRemoveFavoriteProduct, Button.CommandProperty, new Binding() { Path = new PropertyPath(nameof(BeFitViewModel.RemoveFavoriteProduct)), Source = DataContext });         
        }
    }
}
