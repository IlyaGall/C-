using System;

namespace Facade.Problem.Dto
{
    public class PrintFormDataDto
    {
        public Guid Id { get; set; }
        
        public DateTime ExpirationDate { get; set; }
        
        public DateTime StartDate { get; set; }
    }
}