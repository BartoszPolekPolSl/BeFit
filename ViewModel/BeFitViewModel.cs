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
    using System.Windows;
    using System.Windows.Controls;
    using View;

    public class BeFitViewModel : ViewModel
    {
        #region Delegates
        public delegate void UnselectListBoxIndex();
        public UnselectListBoxIndex UnselectEatenProductsIndex;
        #endregion

        #region Private
        private Model model;
        private double eatenKcal;
        private object currentView;
        private string currentDate; 
        private EatenProduct currentEatenProduct;
        #endregion

        #region Constructors
        public BeFitViewModel(Model model)
        {             
            this.model = model;
            User = model.User;            
            EatenProducts = model.EatenProducts;
            FavoriteProducts = model.FavoriteProducts;
            currentEatenProduct = new EatenProduct();
            AddProductView = new AddProductView(this);
            SettingsView = new SettingsView(User);
            CurrentView = AddProductView;
            CurrentDate = DateTime.Now.ToString();
            EatenKcal = model.getEatenKcal();
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

        public double EatenKcal
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
        public ICommand AddEatenProduct => _addEatenProduct ?? (_addEatenProduct = new RelayCommand((p) => { addEatenProduct(); }, p => true));

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


        #endregion

        #region Methods
        private void addEatenProduct()
        {
            Product product = new Product(CurrentProductName, CurrentFats, CurrentCarbohydrates, CurrentProteins, CurrentKcal);
            EatenProduct eatenproduct = new EatenProduct(product, CurrentWeight);
            model.AddEatenProductDB(eatenproduct, model.User);
            EatenKcal = model.getEatenKcal();
            SoundPlayer player = new SoundPlayer(BeFit.Properties.Resources.AddProduct);
            player.Load();
            player.Play();
        }
        
        private void editEatenProduct()
        {
            model.EditEatenProductDB(currentEatenProduct);
            model.UpdateFavouriteProductDB();
            EatenKcal = model.getEatenKcal();
        }

        private void removeEatenProduct()
        {
            model.RemoveEatenProductDB(currentEatenProduct);
        }

        private void changeEatenProduct(object parameter)
        {
            AddProductView.listBoxFavoriteProducts.SelectedIndex = -1;
            if (parameter != null)
            {
                EatenProduct eatenproduct = (EatenProduct)parameter;
                currentEatenProduct = eatenproduct;
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
        }

        private void logOut()
        {
            var result=MessageBox.Show("Czy napewno chcesz się wylogować?", "Uwaga!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                App.LogOut();
            }
        }

        private async void updateTime()
        {
            CurrentDate = DateTime.Now.ToString("G");
            await Task.Delay(1000);
            updateTime();
        }

        // TODO: move this code
        private void getKcalTarget()
        {
            if (User.Sex == Sex.male.ToString())
            {
                UserTarget = (((9.99 * User.Weight) + (6.25 * User.Height) - (4.92 * User.Age) + 5) * getActivityDoubleValue(User.Activity)) + getTargetDoubleValue(User.Target);
            }
            else
            {
                UserTarget = (((9.99 * User.Weight) + (6.25 * User.Height) - (4.92 * User.Age) - 161) * getActivityDoubleValue(User.Activity)) + getTargetDoubleValue(User.Target);
            }
        }

        private double getActivityDoubleValue(string activity)
        {
            if (activity == Activity.lack.ToString())
            {
                return 1.2;
            }
            else if(activity == Activity.little.ToString())
            {
                return 1.3;
            }
            else if (activity == Activity.medium.ToString())
            {
                return 1.5;
            }
            else if (activity == Activity.high.ToString())
            {
                return 1.7;
            }
            else
            {
                return 2;
            }
        }

        private int getTargetDoubleValue(string target)
        {
            if (target == Target.keep.ToString())
            {
                return 0;
            }
            else if (target == Target.lose.ToString())
            {
                return -200;
            }
            else
            {
                return 200;
            }
        }
        #endregion
    }


}
