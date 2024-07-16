using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    static class Menu
    {
        /// <summary>
        /// запуск приложения
        /// </summary>
        static public void start()
        {
            bool exit = false;
            Console.WriteLine("введите команду!");
            while (!exit)
            {
                string? command = Console.ReadLine();
                switch (command)
                {
                    case "/Info":
                        Console.WriteLine(RequestCommand.info());
                        break;
                    case "/exit":
                        exit = true;
                        break;
                    case "/получить всё акции":
                        Request.quest("вернуть все акции за сегодняшний день", RequestCommand.QueryStatisticAll());
                        break;
                    case "/обновить бд":
                        Request.quest("Обновить бд DataStock", RequestCommand.QueryGetAllAction());
                        break;
                    case "/получение свечи":
                        Request.quest("Обновить бд DataStock", RequestCommand.QueryCandle());
                        break;
                    case "/индекс мосбиржи":
                        Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange());
                        break;
                    case "":// для быстрого тестирования
                        Console.WriteLine("введите даты. Две даты через пробел, например 2024-09-23 2024-10-28\n если этого не сделать, то по умолчанию будут взята текущая дата");
                        string? data = Console.ReadLine();
                        if (string.IsNullOrEmpty(data))
                        {
                            Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange());
                        }
                        else 
                        {
                            Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange(data.Split(' ')[0], data.Split(' ')[1]));
                        }
                        break;
                    case "test":
                        Request.quest("", @"https://iss.moex.com/iss/index.xml");
                        break;


                    // индекс мосбиржи https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/imoex.xml?iss.meta=off&iss.only=history&history.columns=CLOSE,TRADEDATE&from=2024-01-01&till=2024-01-30

                    ///"https://raw.githubusercontent.com/d10xa/holidays-calendar/master/json/calendar.json" #Ссылка на календарь праздников
                    ///
                    //  https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/imoex.json #индекс мосбиржи
                    // http://iss.moex.com/iss/engines/stock/markets/shares/securities/SBER/candles
                    // http://iss.moex.com/iss/engines/stock/markets/shares/securities/SBER/candles.json?from=2021-01-01&till=2021-01-30&interval=10&securities.columns=SECID,PREVPRICE,SHORTNAME
                    // https://iss.moex.com/iss/engines/stock/markets/shares/boards/tqbr/securities.xml?iss.meta=off&iss.only=securities&securities.columns=SECID,PREVPRICE,SHORTNAME
                    default:
                        Console.WriteLine("Ошибка команды!");
                        break;
                }
            }
        }

    }

}
