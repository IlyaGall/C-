using Facade.Solution.Dto;

namespace Facade.Solution
{
    public class DocumentService
    {
        private PrintFormService _printFormService;
        
        public DocumentService(
            PrintFormService printFormService)
        {
            _printFormService = printFormService;
        }

        private void Get(int id)
        {
            
        }

        private void Add(DocumentDto documentDto)
        {
            
        }

        public byte[] GeneratePrintForm(DocumentDto documentDto)
        {
            return _printFormService.Generate(documentDto);
        }
    }
}