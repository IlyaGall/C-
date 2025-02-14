using System;

namespace Decorator.Solution.Decorators
{
    public class SmsNotificationDecorator : BaseDecorator
    {
        public SmsNotificationDecorator(INotificationService notificationService) : base(notificationService)
        {
        }
        
        public override void Notify()
        {
            Console.WriteLine("СМС: Получаем данные, формируем сообщение");
            base.Notify();
            Console.WriteLine("SMS: Отправляем");        }
    }
}