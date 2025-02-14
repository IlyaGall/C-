using CardLibrary;
using Decorator.Solution.Decorators;

namespace Decorator.Solution
{
    public class CardManager
    {
        private CardIssueService _cardIssueService;
        private NotificationOptions _notificationOptions;

        public CardManager(NotificationOptions notificationOptions)
        {
            _cardIssueService = new CardIssueService();
            _notificationOptions = notificationOptions;
        }
        
        public void Issue()
        {
            _cardIssueService.Issue(new Message());
            INotificationService notificationService = new ApplicationNotificationService();
            if (_notificationOptions.SendFBNotification)
            {
                notificationService = new FaceBookDecorator(notificationService);
            } 

            if (_notificationOptions.SendToSms)
            {
                notificationService = new SmsNotificationDecorator(notificationService);
            }

            if (_notificationOptions.SendToEmail)
            {
                notificationService = new EmailNotificationDecorator(notificationService);
            }
            
            notificationService.Notify();
        }
    }
}