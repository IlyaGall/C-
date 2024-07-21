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
        /// вытащить путь к картинкам в сообщении
        /// </summary>
        /// <returns></returns>
        static private string[] parsingPath(string message) 
        {
            string[] pathImg = message.Split('~');
            return null;
        } 

        /// <summary>
        /// отправка пользователю сообщения
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessage(string message) 
        {
            //пока поставлю заглушку, в виде writeline
            
            
            Console.WriteLine(message);

        } 

        /// <summary>
        /// отправка сообщения разработчику о том, чтобы посмотрел что-же пошло не так и подробное описание
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessageDebagger(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
