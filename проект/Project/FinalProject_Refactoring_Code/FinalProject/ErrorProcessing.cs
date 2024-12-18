﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{



    /*
     Задача модуля заключается в том, чтобы не положить сервер и объяснить пользователю, где он не прав.
     */
    /// <summary>
    /// Обработчик ошибок
    /// </summary>
    internal class ErrorProcessing
    {
    /// <summary>
    /// модуль ловли ошибок
    /// </summary>
    /// <param name="message">Дополнительное сообщение о том, где </param>
        static public void start(string message ="")
        {
            try 
            {
                GraphicCreator.DelAllIMGInTemp();
                Menu.start();
            }
            catch(Exception e)  
            {
                Console.WriteLine(e.ToString());
                TelegramBotMessage.SendMessage($"Ошибка {e.Message.ToString()}");
            }
        }

        static public void generateTextError(string message) 
        {
            TelegramBotMessage.SendMessage($"Ошибка. {message}");
        }
    }
}
