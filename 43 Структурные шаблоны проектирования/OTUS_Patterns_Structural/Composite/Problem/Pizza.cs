namespace Composite.Problem
{
    public class Pizza
    {
        private decimal _price;

        public Pizza(decimal price)
        {
            _price = price;
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
}