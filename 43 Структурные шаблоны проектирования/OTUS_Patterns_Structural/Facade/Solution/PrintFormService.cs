using Facade.Solution.Dto;

namespace Facade.Solution
{
    public class PrintFormService
    {
        private PrintFormDataService _printFormDataService;
        private PrintFormTemplateService _printFormTemplateService;
        private PrintFormGenerator _printFormGenerator;
        
        public PrintFormService(
            PrintFormDataService printFormDataService,
            PrintFormTemplateService printFormTemplateService,
            PrintFormGenerator printFormGenerator)
        {
            _printFormDataService = printFormDataService;
            _printFormTemplateService = printFormTemplateService;
            _printFormGenerator = printFormGenerator;
        }

        public byte[] Generate(DocumentDto documentDto)
        {
            var template = _printFormTemplateService.GetTemplate(documentDto.Type);
            var printFormData = _printFormDataService.GetPrintFormData(documentDto);
            var generatedDocument = _printFormGenerator.Generate(template, printFormData);
            return generatedDocument;
        }
    }
}