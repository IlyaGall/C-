using CardLibrary;

namespace Adapter.Solution
{
    public class CardManager
    {
        public void Issue(CardInfo cardInfo)
        {
            var cardIssueService = new CardIssueService();
            ICardIssueServiceAdaptor adaptor = new CardIssueServiceAdaptor(cardIssueService);
            adaptor.Issue(cardInfo);
        }
    }
}