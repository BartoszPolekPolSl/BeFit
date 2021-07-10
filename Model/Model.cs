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
    class Model
    {
        public ObservableCollection<EatenProduct> EatenProducts { get; set; } = new ObservableCollection<EatenProduct>();
        //public ObservableCollection<Product> FavoriteProducts { get; set; } = new ObservableCollection<Product>();
        private User user=null;
        public Model(User user)
        {
            this.user = user;
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

        public bool IfEatenProductIsInDB(Product product)
        {
            if (EatenProducts.Contains(product))
            {
                return true;
            }
            else
            {
                return false;
            }
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
