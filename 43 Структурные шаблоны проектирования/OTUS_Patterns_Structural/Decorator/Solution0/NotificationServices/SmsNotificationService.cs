using System;

namespace Decorator.Solution.NotificationServices
{
    public class SmsNotificationService
    {
        public void Notify()
        {
            //Получаем данные, формируем сообщение
            Console.WriteLine("Notify Sms pre action");
            Console.WriteLine("Notify Sms post action");
        }
    }
}