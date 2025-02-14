namespace Composite.Solution
{
    public class Pie : IProduct
    {
        private decimal _price;

        public Pie(decimal price)
        {
            _price = price;
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
}