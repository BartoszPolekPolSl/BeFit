using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    using DAL.Entities;
    using DAL.Repositories;
    public class Model
    {
        public ObservableCollection<EatenProduct> EatenProducts { get; set; } = new ObservableCollection<EatenProduct>();
        public ObservableCollection<Product> FavoriteProducts { get; set; } = new ObservableCollection<Product>();
        public User User=null;
        public Model(User user)
        {
            this.User = user;
            UpdateEatenProductDB();
            UpdateFavouriteProductDB();
        }

        public bool AddEatenProductDB(EatenProduct eatenproduct, User user)
        {
            if (EatenProductsRepository.AddProductDB(eatenproduct, user))
            {
                EatenProducts.Add(eatenproduct);
                return true;
            }
            return false;
        }

        public bool EditEatenProductDB(EatenProduct eatenproduct)
        {
            if (EatenProductsRepository.EditProductDB(eatenproduct))
            {
                UpdateEatenProductDB();
            }
            return false;
        }

        public bool RemoveEatenProductDB(EatenProduct eatenproduct)
        {
            if (EatenProductsRepository.RemoveProductDB(eatenproduct))
            {
                EatenProducts.Remove(eatenproduct);
                return true;
            }
            return false;
        }

        public bool AddFavoriteProductDB(Product product, User user)
        {
            if (FavoriteProductsRepository.AddProductDB(product, user))
            {
                FavoriteProducts.Add(product);
                return true;
            }
            return false;
        }

        public bool RemoveFavoriteProductDB(Product product)
        {
            if (FavoriteProductsRepository.RemoveProductDB(product))
            {
                UpdateFavouriteProductDB();
            }
            return false;
        }

        public bool EditFavoriteProductDB(Product product)
        {
            if (FavoriteProductsRepository.EditProductDB(product))
            {
                UpdateFavouriteProductDB();
            }
            return false;
        }

        public void UpdateFavouriteProductDB()
        {
            FavoriteProducts.Clear();
            var favoriteproducts = FavoriteProductsRepository.GetAllUserFavoriteProducts(User);
            foreach (var o in favoriteproducts)
            {
                FavoriteProducts.Add(o);
            }
        }

        public void UpdateEatenProductDB()
        {
            EatenProducts.Clear();
            var eatenproducts = EatenProductsRepository.GetAllUserEatenProducts(User);
            foreach (var o in eatenproducts)
            {
                EatenProducts.Add(o);
            }
        }

    }
}
