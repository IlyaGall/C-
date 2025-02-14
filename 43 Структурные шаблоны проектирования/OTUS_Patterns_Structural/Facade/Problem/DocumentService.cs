using Facade.Problem.Dto;

namespace Facade.Problem
{
    public class DocumentService
    {
        private PrintFormDataService _printFormDataService;
        private PrintFormTemplateService _printFormTemplateService;
        private PrintFormGenerator _printFormGenerator;
        
        public DocumentService(
            PrintFormDataService printFormDataService,
            PrintFormTemplateService printFormTemplateService,
            PrintFormGenerator printFormGenerator)
        {
            _printFormDataService = printFormDataService;
            _printFormTemplateService = printFormTemplateService;
            _printFormGenerator = printFormGenerator;
        }

        private void Get(int id)
        {
            
        }

        private void Add(DocumentDto documentDto)
        {
            
        }

        public byte[] GeneratePrintForm(DocumentDto documentDto)
        {
            var template = _printFormTemplateService.GetTemplate(documentDto.Type);
            var printFormData = _printFormDataService.GetPrintFormData(documentDto);
            var generatedDocument = _printFormGenerator.Generate(template, printFormData);
            return generatedDocument;
        }
    }
}