using System;

namespace Decorator.Solution.NotificationServices
{
    public class EmailNotificationService
    {
        public void Notify()
        {
            //Получаем данные, формируем сообщение
            Console.WriteLine("Notify Email pre action");
            Console.WriteLine("Notify Email post action");
        }
    }
}