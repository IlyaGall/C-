using System;

namespace Decorator.Solution
{
    public sealed class ApplicationNotificationService : INotificationService
    {
        public void Notify()
        {
            Console.WriteLine("Приложение: Получаем данные, формируем сообщение");
            Console.WriteLine("Приложение: Отправляем");
        }
    }
}