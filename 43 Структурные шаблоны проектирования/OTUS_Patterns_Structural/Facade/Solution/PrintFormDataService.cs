using Facade.Solution.Dto;

namespace Facade.Solution
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