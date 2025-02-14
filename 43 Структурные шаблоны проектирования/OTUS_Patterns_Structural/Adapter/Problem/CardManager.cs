using CardLibrary;

namespace Problem
{
    public class CardManager
    {
        public void Issue(CardInfo cardInfo)
        {
            var cardIssueService = new CardIssueService();
            //cardIssueService.Issue();
        }
    }
}