using System;

namespace Decorator.Solution.Decorators
{
    public class FaceBookDecorator : BaseDecorator
    {
        public FaceBookDecorator(INotificationService notificationService) 
            : base(notificationService)
        {
        }
        
        public override void Notify()
        {
            Console.WriteLine("FB: Получаем данные, формируем сообщение");
            base.Notify();
            Console.WriteLine("FB: Отправляем");
        }
    }
}