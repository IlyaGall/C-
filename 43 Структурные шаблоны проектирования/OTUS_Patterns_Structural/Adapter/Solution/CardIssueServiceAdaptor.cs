using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CardLibrary;

namespace Adapter.Solution
{
    public class CardIssueServiceAdaptor : ICardIssueServiceAdaptor
    {
        private readonly CardIssueService _cardIssueService;
        public CardIssueServiceAdaptor(CardIssueService cardIssueService)
        {
            _cardIssueService = cardIssueService;
        }
        
        public void Issue(CardInfo cardInfo)
        {
            var cardInfoXml = Serialize<CardInfo>(cardInfo);
            _cardIssueService.Issue(new Message
            {
                Content = cardInfoXml 
            });
        }

        private string Serialize<T>(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);
                    return sww.ToString();
                }
            }
        }
    }
}