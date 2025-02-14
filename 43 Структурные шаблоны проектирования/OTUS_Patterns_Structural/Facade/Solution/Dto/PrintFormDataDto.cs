using System;

namespace Facade.Solution.Dto
{
    public class PrintFormDataDto
    {
        public Guid Id { get; set; }
        
        public DateTime ExpirationDate { get; set; }
        
        public DateTime StartDate { get; set; }
    }
}