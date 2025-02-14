namespace Composite.Problem
{
    public class Pie 
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