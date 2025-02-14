namespace Decorator.Solution.Decorators
{
    public class BaseDecorator : INotificationService
    {
        private readonly INotificationService _notificationService;

        protected BaseDecorator(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        public virtual void Notify()
        {
            _notificationService.Notify();
        }
    }
}