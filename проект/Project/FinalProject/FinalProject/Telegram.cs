using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// работа с телеграмом
    /// </summary>
     internal class Telegram
    {
        /// <summary>
        /// отправка пользователю сообщения
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessage(string message) 
        {
            //пока поставлю заглушку, в виде writeline
            Console.WriteLine(message);
        } 
    }
}
