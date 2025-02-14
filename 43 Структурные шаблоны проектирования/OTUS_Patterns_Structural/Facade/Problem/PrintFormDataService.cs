using Facade.Problem.Dto;

namespace Facade.Problem
{
    public class PrintFormDataService
    {
        public PrintFormDataService()
        {
            
        }
        
        public PrintFormDataDto GetPrintFormData(DocumentDto documentDto)
        {
            var printFormData = new PrintFormDataDto();
            return printFormData;
        }
    }
}