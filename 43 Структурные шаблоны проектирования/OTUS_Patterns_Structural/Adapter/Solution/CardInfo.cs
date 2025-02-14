using System;

namespace Adapter.Solution
{
    public class CardInfo
    {
        public Guid Id { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime ExpirationDate { get; set; }
    }
}