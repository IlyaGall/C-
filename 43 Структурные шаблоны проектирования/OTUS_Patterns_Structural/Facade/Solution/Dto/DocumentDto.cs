using System;

namespace Facade.Solution.Dto
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        
        public int Type { get; set; }
        
        public int SubType { get; set; }
        
        public DateTime CreationDate { get; set; }
    }
}