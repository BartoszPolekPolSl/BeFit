using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFit.Model
{
    class ProductsList
    {
        private List<Product> productsList;
        public ProductsList()
        {
            productsList = new List<Product>();
        }
        public Product this[int index]
        {
            get
            {
                return productsList[index];
            }
        }
        public void Add(Product product)
        {
            productsList.Add(product);
        }
        public double GetSumKcal()
        {
            double sum=0.0;
            foreach(Product product in productsList)
            {
                sum += product.Kcal;
            }
            return sum;
        }           
    }
}
