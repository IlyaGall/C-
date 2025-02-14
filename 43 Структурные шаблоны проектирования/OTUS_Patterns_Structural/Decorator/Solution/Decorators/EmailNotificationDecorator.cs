using System;

namespace Decorator.Solution.Decorators
{
    public class EmailNotificationDecorator : BaseDecorator
    {
        public EmailNotificationDecorator(INotificationService notificationService) : base(notificationService)
        {
        }
        
        public override void Notify()
        {
            Console.WriteLine("Email: Получаем данные, формируем сообщение");
            base.Notify();
            Console.WriteLine("Email: Отправляем");
        }
    }
}