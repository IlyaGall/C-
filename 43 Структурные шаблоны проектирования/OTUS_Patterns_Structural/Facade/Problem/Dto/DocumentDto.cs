using System;

namespace Facade.Problem.Dto
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        
        public int Type { get; set; }
        
        public int SubType { get; set; }
        
        public DateTime CreationDate { get; set; }
    }
}