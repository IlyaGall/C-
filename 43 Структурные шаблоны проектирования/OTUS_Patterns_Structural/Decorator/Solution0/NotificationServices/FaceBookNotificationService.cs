using System;

namespace Decorator.Solution.NotificationServices
{
    public class FaceBookNotificationService
    {
        public void Notify()
        {
            //Получаем данные, формируем сообщение
            Console.WriteLine("Notify Facebook pre action");
            Console.WriteLine("Notify Facebook post action");
        }
    }
}