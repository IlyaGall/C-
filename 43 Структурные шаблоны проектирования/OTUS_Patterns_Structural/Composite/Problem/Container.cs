namespace Composite.Problem
{
    public class Container
    {
        private decimal _price;

        public Container(decimal price)
        {
            _price = price;
        }
        
        public decimal GetPrice()
        {
            return _price;
        }
    }
}