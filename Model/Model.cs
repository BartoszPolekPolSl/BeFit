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
        //public ObservableCollection<Product> FavoriteProducts { get; set; } = new ObservableCollection<Product>();
        public User User=null;
        public Model(User user)
        {
            this.User = user;
            var eatenproducts = EatenProductsRepository.GetAllUserEatenProducts(user);
            foreach(var o in eatenproducts)
            {
                EatenProducts.Add(o);
            }
            //var favoriteproducts = FavoriteProductsRepository.GetAllUserFavoriteProducts(user);
            //foreach (var o in favoriteproducts)
            //{
            //    FavoriteProducts.Add(o);
            //}
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
                EatenProducts.Clear();
                var eatenproducts = EatenProductsRepository.GetAllUserEatenProducts(User);
                foreach (var o in eatenproducts)
                {
                    EatenProducts.Add(o);
                }
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

        //public bool IfFavoriteProductIsInDB(EatenProduct product)
        //{
        //    if (FavoriteProducts.Contains(product))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
