using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeFit.ViewModel
{
    using BaseClass;
    using DAL.Entities;
    using Model;
    using System.Collections.ObjectModel;
    using System.Media;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using View;

    public class BeFitViewModel : ViewModel
    {
        #region Delegates
        public delegate void UnselectListBoxIndex();
        public event UnselectListBoxIndex UnselectEatenProductsIndex;
        #endregion

        #region Private
        private Model model;
        private object currentView;
        private string currentDate, eatenProteins, eatenCarbohydrates, eatenFats, eatenKcal;
        private EatenProduct currentEatenProduct;
        private Calculator calculator;
        private SettingsViewModel settingsViewModel;
        #endregion

        #region Constructors
        public BeFitViewModel(Model model)
        {
            this.model = model;
            calculator = new Calculator(model);
            User = model.User;
            EatenProducts = model.EatenProducts;
            FavoriteProducts = model.FavoriteProducts;
            currentEatenProduct = new EatenProduct();
            AddProductView = new AddProductView(this);
            SettingsView = new SettingsView(User);
            settingsViewModel = (SettingsViewModel)SettingsView.DataContext;
            settingsViewModel.UpdateUserInfo += updateUserInfo;
            CurrentView = AddProductView;
            CurrentDate = DateTime.Now.ToString();
            updateEatenComponents();
            updateTime();
        }
        #endregion

        #region Properties
        public User User { get; set; }

        public AddProductView AddProductView { get; set; }

        public SettingsView SettingsView { get; set; }

        public ObservableCollection<EatenProduct> EatenProducts { get; set; }

        public ObservableCollection<Product> FavoriteProducts { get; set; }

        public string Username { get { return User.UserName; } set { } }

        public string FunFact { get { return model.FunFact;} }

        public double UserTarget { get; set; }

        public string UserSex
        {
            get
            {
                if (User.Sex == "male")
                    return "Mężczyzna";
                else
                    return "Kobieta";
            }
        }

        public string CurrentDate
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                OnPropertyChange(nameof(CurrentDate));
            }
        }

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChange(nameof(CurrentView));
            }
        }

        public string EatenKcal
        {
            get { return eatenKcal; }
            set
            {
                eatenKcal = value;
                OnPropertyChange(nameof(EatenKcal));
            }
        }

        public double CurrentProteins
        {
            get { return currentEatenProduct.Proteins; }
            set
            {
                currentEatenProduct.Proteins = value;
                OnPropertyChange(nameof(CurrentProteins));
            }
        }

        public double CurrentFats
        {
            get { return currentEatenProduct.Fats; }
            set
            {
                currentEatenProduct.Fats = value;
                OnPropertyChange(nameof(CurrentFats));
            }
        }

        public double CurrentCarbohydrates
        {
            get { return currentEatenProduct.Carbohydrates; }
            set
            {
                currentEatenProduct.Carbohydrates = value;
                OnPropertyChange(nameof(CurrentCarbohydrates));
            }
        }

        public double CurrentKcal
        {
            get { return currentEatenProduct.Kcal; }
            set
            {
                currentEatenProduct.Kcal = value;
                OnPropertyChange(nameof(CurrentKcal));
            }
        }

        public double CurrentWeight
        {
            get { return currentEatenProduct.Weight; }
            set
            {
                currentEatenProduct.Weight = value;
                OnPropertyChange(nameof(CurrentWeight));
            }
        }

        public string EatenProteins
        {
            get { return eatenProteins; }
            set
            {
                eatenProteins = value;
                OnPropertyChange(nameof(EatenProteins));
            }
        }

        public string EatenFats
        {
            get { return eatenFats; }
            set
            {
                eatenFats = value;
                OnPropertyChange(nameof(EatenFats));
            }
        }

        public string EatenCarbohydrates
        {
            get { return eatenCarbohydrates; }
            set
            {
                eatenCarbohydrates = value;
                OnPropertyChange(nameof(EatenCarbohydrates));
            }
        }

        public string CurrentProductName
        {
            get { return currentEatenProduct.Name; }
            set
            {
                currentEatenProduct.Name = value;
                OnPropertyChange(nameof(CurrentProductName));
            }
        }

        #endregion

        #region Commands
        private ICommand _changeToAddProductView;
        public ICommand ChangeToAddProductView => _changeToAddProductView ?? (_changeToAddProductView = new RelayCommand((p) => { CurrentView = AddProductView; }, p => true));

        private ICommand _changeToSettingsView;
        public ICommand ChangeToSettingsView => _changeToSettingsView ?? (_changeToSettingsView = new RelayCommand((p) => { CurrentView = SettingsView; }, p => true));

        private ICommand _logOut;
        public ICommand LogOut => _logOut ?? (_logOut = new RelayCommand((p) => { logOut(); }, p => true));

        private ICommand _addEatenProduct;
        public ICommand AddEatenProduct => _addEatenProduct ?? (_addEatenProduct = new RelayCommand((p) => { addEatenProduct(); }, p => checkEatenProduct()));

        private ICommand _changeEatenProduct;
        public ICommand ChangeEatenProduct => _changeEatenProduct ?? (_changeEatenProduct = new RelayCommand((p) => { changeEatenProduct(p); }, p => true));

        private ICommand _removeEatenProduct;
        public ICommand RemoveEatenProduct => _removeEatenProduct ?? (_removeEatenProduct = new RelayCommand((p) => { removeEatenProduct(); }, p => true));

        private ICommand _editEatenProduct;
        public ICommand EditEatenProduct => _editEatenProduct ?? (_editEatenProduct = new RelayCommand((p) => { editEatenProduct(); }, p => true));

        private ICommand _addFavoriteProduct;
        public ICommand AddFavoriteProduct => _addFavoriteProduct ?? (_addFavoriteProduct = new RelayCommand((p) => { addFavoriteProduct(); }, p => true));


        private ICommand _changeFavoriteProduct;
        public ICommand ChangeFavoriteProduct => _changeFavoriteProduct ?? (_changeFavoriteProduct = new RelayCommand((p) => { changeFavoriteProduct(p); }, p => true));

        private ICommand _removeFavoriteProduct;
        public ICommand RemoveFavoriteProduct => _removeFavoriteProduct ?? (_removeFavoriteProduct = new RelayCommand((p) => { removeFavoriteProduct(); }, p => true));

        private ICommand _editFavoriteProduct;
        public ICommand EditFavoriteProduct => _editFavoriteProduct ?? (_editFavoriteProduct = new RelayCommand((p) => { editFavoriteProduct(); }, p => true));

        private ICommand _checkIfTextBoxHasDigit;
        public ICommand CheckIfTextBoxHasDigit => _checkIfTextBoxHasDigit ?? (_checkIfTextBoxHasDigit = new RelayCommand((p) => { textBoxDigitOnly(p); }, p => true));

        private ICommand _textBoxLostFocus;
        public ICommand TextBoxLostFocus => _textBoxLostFocus ?? (_textBoxLostFocus = new RelayCommand((p) => { lostFocus(p); }, p => true));


        #endregion

        #region Methods

        private bool checkEatenProduct()
        {

            if (string.IsNullOrWhiteSpace(CurrentProductName))
            {
                return false;
            }
            return true;
        }
        private void lostFocus(Object obj)
        {
            var textBox = (TextBox)obj;
            if (textBox.Text == "" || string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = 0.ToString();
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void addEatenProduct()
        {

            Product product = new Product(CurrentProductName, CurrentFats, CurrentCarbohydrates, CurrentProteins, CurrentKcal);
            EatenProduct eatenproduct = new EatenProduct(product, CurrentWeight);
            model.AddEatenProductDB(eatenproduct, model.User);
            updateEatenComponents();
            SoundPlayer player = new SoundPlayer(BeFit.Properties.Resources.AddProduct);
            player.Load();
            player.Play();
        }

        private void editEatenProduct()
        {
            model.EditEatenProductDB(currentEatenProduct);
            model.UpdateFavouriteProductDB();
            updateEatenComponents();
        }

        private void removeEatenProduct()
        {
            model.RemoveEatenProductDB(currentEatenProduct);
            updateEatenComponents();
        }

        private void changeEatenProduct(object parameter)
        {
            AddProductView.listBoxFavoriteProducts.SelectedIndex = -1;
            if (parameter != null)
            {
                EatenProduct eatenproduct = (EatenProduct)parameter;
                currentEatenProduct = new EatenProduct( eatenproduct);
                OnPropertyChange(nameof(CurrentCarbohydrates), nameof(CurrentFats), nameof(CurrentKcal), nameof(CurrentProteins), nameof(CurrentWeight), nameof(CurrentProductName));
            }
            else
            {
                currentEatenProduct = new EatenProduct();
                OnPropertyChange(nameof(CurrentCarbohydrates), nameof(CurrentFats), nameof(CurrentKcal), nameof(CurrentProteins), nameof(CurrentWeight), nameof(CurrentProductName));
            }
        }

        private void changeFavoriteProduct(object parameter)
        {
            UnselectEatenProductsIndex.Invoke();
            if (parameter != null)
            {
                Product product = (Product)parameter;
                currentEatenProduct = new EatenProduct(product);
                OnPropertyChange(nameof(CurrentCarbohydrates), nameof(CurrentFats), nameof(CurrentKcal), nameof(CurrentProteins), nameof(CurrentWeight), nameof(CurrentProductName));
            }
            else
            {
                currentEatenProduct = new EatenProduct();
                OnPropertyChange(nameof(CurrentCarbohydrates), nameof(CurrentFats), nameof(CurrentKcal), nameof(CurrentProteins), nameof(CurrentWeight), nameof(CurrentProductName));
            }
        }

        private void addFavoriteProduct()
        {
            Product product = new Product(CurrentProductName, CurrentFats, CurrentCarbohydrates, CurrentProteins, CurrentKcal);
            model.AddFavoriteProductDB(product, User);
        }

        private void removeFavoriteProduct()
        {
            model.RemoveFavoriteProductDB(currentEatenProduct);
        }

        private void editFavoriteProduct()
        {
            model.EditFavoriteProductDB(currentEatenProduct);
            model.UpdateEatenProductDB();
            updateEatenComponents();
        }

        private void logOut()
        {
            var result = MessageBox.Show("Czy napewno chcesz się wylogować?", "Uwaga!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                App.LogOut();
            }
        }

        private void updateEatenComponents()
        {
            EatenProteins = $"{calculator.GetEatenProteins()}/{calculator.GetProteinsTarget()}";
            EatenFats = $"{calculator.GetEatenFats()}/{calculator.GetFatsTarget()}";
            EatenCarbohydrates = $"{calculator.GetEatenCarbohydrates()}/{calculator.GetCarbohydratesTarget()}";
            EatenKcal = $"{calculator.GetEatenKcal()}/{calculator.GetKcalTarget()}";
        }

        private void updateUserInfo(string sex, double weight, int height, int age, string activity, string target)
        {
            User.Sex = sex;
            User.Weight = weight;
            User.Height = height;
            User.Age = age;
            User.Activity = activity;
            User.Target = target;
            updateEatenComponents();
        }

        private async void updateTime()
        {
            CurrentDate = DateTime.Now.ToString("G");
            await Task.Delay(1000);
            updateTime();
        }

        private void textBoxDigitOnly(Object obj)
        {
            var textBox = (TextBox)obj;
            if (textBox.Text != "")
            {
                char lastChar = textBox.Text.Last<char>();
                if (!char.IsDigit(lastChar) && lastChar != '.')
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                    textBox.ToolTip = "Wprowadzone dane mogą być tylko liczbą, jeżeli chcesz wpisać liczbą niecałkowitą, wpisz ją za pomocą '.'";
                }
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        // TODO: move this code

        #endregion
    }


}
