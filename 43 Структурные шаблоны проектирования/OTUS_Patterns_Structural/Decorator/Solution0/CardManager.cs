using CardLibrary;
using Decorator.Solution.NotificationServices;

namespace Decorator.Solution
{
    public class CardManager
    {
        private CardIssueService _cardIssueService;
        private NotificationOptions _notificationOptions;
        private FaceBookNotificationService _faceBookNotificationService;
        private SmsNotificationService _smsNotificationService;
        private EmailNotificationService _emailNotificationService;
        private ApplicationNotifier _applicationNotifier;
        
        public CardManager(NotificationOptions notificationOptions)
        {
            _cardIssueService = new CardIssueService();
            _notificationOptions = notificationOptions;
            _smsNotificationService = new SmsNotificationService();
            _emailNotificationService = new EmailNotificationService();
            _faceBookNotificationService = new FaceBookNotificationService();
            _applicationNotifier = new ApplicationNotifier();
        }
        
        public void Issue()
        {
            _cardIssueService.Issue(new Message());
            
            _applicationNotifier.Notify();
            if (_notificationOptions.SendFBNotification)
            {
                _faceBookNotificationService.Notify();
            } 

            if (_notificationOptions.SendToSms)
            {
                _smsNotificationService.Notify();
            }

            if (_notificationOptions.SendToEmail)
            {
                _emailNotificationService.Notify();
            }
        }
    }
}