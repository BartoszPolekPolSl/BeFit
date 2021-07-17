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
    using View;

    public class BeFitViewModel : ViewModel
    {
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
            currentEatenProduct = new EatenProduct();
            AddProductView = new AddProductView(this);
            this.model = model;
            User = model.User;            
            EatenProducts = model.EatenProducts;
            CurrentView = AddProductView;
            CurrentDate = DateTime.Now.ToString();
            getEatenKcal();
            updateTime();
        }
        #endregion

        #region Properties
        public User User { get; set; }

        public AddProductView AddProductView { get; set; }

        public ObservableCollection<EatenProduct> EatenProducts { get; set; }


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

        private ICommand _add;
        public ICommand Add => _add ?? (_add = new RelayCommand((p) => { addEatenProductDB(); }, p => true));

        private ICommand _change;
        public ICommand Change => _change ?? (_change = new RelayCommand((p) => { changeEatenProduct(p); }, p => true));

        private ICommand _remove;
        public ICommand Remove => _remove ?? (_remove = new RelayCommand((p) => { removeEatenProductDB(); }, p => true));

        private ICommand _edit;
        public ICommand Edit => _edit ?? (_edit = new RelayCommand((p) => { editEatenProductDB(); }, p => true));

        #endregion

        #region Methods
        private void addEatenProductDB()
        {
            Product product = new Product(CurrentProductName, CurrentFats, CurrentCarbohydrates, CurrentProteins, CurrentKcal);
            EatenProduct eatenproduct = new EatenProduct(product, CurrentWeight);
            model.AddEatenProductDB(eatenproduct, model.User);
            getEatenKcal();
            SoundPlayer player = new SoundPlayer(BeFit.Properties.Resources.AddProduct);
            player.Load();
            player.Play();
        }

        private void editEatenProductDB()
        {
            model.EditEatenProductDB(currentEatenProduct);
            getEatenKcal();
        }

        private void removeEatenProductDB()
        {
            model.RemoveEatenProductDB(currentEatenProduct);
        }

        private void changeEatenProduct(object parameter)
        {
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

        private void getEatenKcal()
        {
            double sum=0;
            foreach(EatenProduct product in model.EatenProducts)
            {
                sum += product.EatenKcal;
            }
            EatenKcal = sum;
        }

        private async void updateTime()
        {
            CurrentDate = DateTime.Now.ToString("G");
            await Task.Delay(1000);
            updateTime();
        }
        #endregion
    }


}
