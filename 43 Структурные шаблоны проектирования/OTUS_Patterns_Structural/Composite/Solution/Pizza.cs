namespace Composite.Solution
{
    public class Pizza : IProduct
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