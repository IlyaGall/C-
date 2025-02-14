using System.Collections.Generic;

namespace Composite.Solution
{
    public class Container : IProduct
    {
        private decimal _price;

        private List<IProduct> _products;

        public Container(decimal price)
        {
            _price = price;
            _products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }
        
        public decimal GetPrice()
        {
            var totalPrice = _price;
            foreach (var product in _products)
            {
                totalPrice += product.GetPrice();
            }

            return totalPrice;
        }
    }
}