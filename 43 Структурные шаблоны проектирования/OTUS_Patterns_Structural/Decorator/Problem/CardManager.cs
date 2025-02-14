using CardLibrary;

namespace Decorator.Problem
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
            INotificationService notificationService = new ApplicationNotifier();
            notificationService.Notify();
            
            if (_notificationOptions.SendFBNotification)
            {
                //notificationService.NotifyFB();
            }

            if (_notificationOptions.SendFBNotification && _notificationOptions.SendToSms)
            {
                //notificationService.NotifyFB();
                //notificationService.NotifySms();
            }

            if (_notificationOptions.SendToSms && _notificationOptions.SendFBNotification && _notificationOptions.SendToEmail)
            {
                //notificationService.NotifySms();
                //notificationService.NotifyFb();
                //notificationService.NotifyEmail();
            }
        }
    }
}