using ScottPlot.Colormaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{



    static class Menu
    {
        #region управление курсором меню
        /// <summary>
        /// количество элементов в меню на текущий момент
        /// </summary>
        static public int AmountElementsInNowMenu = 0;

        /// <summary>
        /// Исходное положение стрелки меню
        /// </summary>
        static public int selectedValue = 0;

        /// <summary>
        /// стек текущей навигации пользователя
        /// </summary>
        static public List<string> stackNavigation = new List<string>() { "Main menu" };

        /// <summary>
        /// На одну строку вниз
        /// </summary>
        private static void SetDown()
        {
            if (selectedValue < AmountElementsInNowMenu)
            {
                selectedValue++;
            }
            else
            {
                selectedValue = 1;
            }
        }

        /// <summary>
        /// На одну строку вверх
        /// </summary>
        private static void SetUp()
        {
            if (selectedValue > 1)
            {
                selectedValue--;
            }
            else
            {
                selectedValue = AmountElementsInNowMenu;
            }
        }
        private static void WriteCursor(int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(">");
            Console.SetCursorPosition(0, pos);
        }

        private static void ClearCursor(int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(" ");
            Console.SetCursorPosition(0, pos);
        }


        #endregion





        /// <summary>
        /// Вывести меню
        /// </summary>

        private static void PrintMenu()
        {
            if (stackNavigation.Count > 0)
            {
                switch (stackNavigation[stackNavigation.Count - 1])
                {
                    case "Main menu":
                        Console.WriteLine("Для выхода нажмите Escape");
                        for (var i = 0; i < optionsMainMenu.Length; i++)
                        {
                            Console.WriteLine($" {i + 1}. {optionsMainMenu[i]}");
                        }
                        AmountElementsInNowMenu = optionsMainMenu.Length;
                        break;
                    case "Setting":
                        Console.WriteLine("Для выхода нажмите Escape");
                        for (var i = 0; i < settings.Length; i++)
                        {
                            Console.WriteLine($" {i + 1}. {settings[i]}");

                        }
                        AmountElementsInNowMenu = settings.Length;
                        break;
                    case "Author":
                        Console.WriteLine(" Для выхода нажмите Escape");
                        for (var i = 0; i < author.Length; i++)
                        {
                            Console.WriteLine($" {i + 1}. {author[i]}");

                        }
                        AmountElementsInNowMenu = author.Length;
                        selectedValue = 0;
                        Settings.GlobalParameters.Images();
                        break;
                }
            }

        }



        /// <summary>
        /// Опции меню
        /// </summary>
        private static string[] optionsMainMenu = new[]
        {
            "Запустить сервер",
            "Настройки",
            "Автор",
            "Выход из программы"

        };

        private static string[] settings = new[] {
            $"Временное хранение файлов графиков '{Settings.GlobalParameters.PATH_SAVE}'",
             $"Сбросить файл настроек по умолчанию",
            $"Версия по '{Settings.GlobalParameters.VERSION_PROGRAM}'",
            "Выход в меню"
        };

        /// <summary>
        /// обновление массива 
        /// </summary>
        /// <returns></returns>
        private static void updateArraySetting()
        {
            settings = new[] {
            $"Временное хранение файлов графиков '{Settings.GlobalParameters.PATH_SAVE}'",
            $"Сбросить файл настроек по умолчанию",
            $"Версия по '{Settings.GlobalParameters.VERSION_PROGRAM}'",
            "Выход в меню"
            };

        }

        private static string[] author = new[] {
            $"Автор ПО '{Settings.GlobalParameters.AVTOR}'",
        };

        static private bool navigation(string movement = "+")
        {
            
            if (movement == "+")
            {//переключение по меню
                switch (selectedValue)
                {
                    case 0:
                        break;
                    case 1:
                        if (stackNavigation[stackNavigation.Count - 1] == "Main menu")
                        {
                            Console.Clear();
                            startServer();
                        }
                        if (stackNavigation[stackNavigation.Count - 1] == "Setting")
                        {
                            Console.Clear();
                            Console.WriteLine("Введите новый путь(ПКМ вставить из буфера обмена) если ничего не ввести, то новый путь не будет установлен:");
                            string? s = Console.ReadLine();
                            if (Settings.CorrectPathDirectory(s))
                            {
                                Settings.GlobalParameters.PATH_SAVE = s;
                                updateArraySetting();
                                Console.Clear();
                                PrintMenu();
                            }
                            else
                            {
                                Console.Clear();
                                PrintMenu();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Внимание не удалось изменить путь на '{s}' путь сброшен на дефолтный {Settings.GlobalParameters.PATH_SAVE} \n{Settings.GlobalParameters.ERROR}\nЧтобы ещё раз попробовать выберите пункт 1 и нажмите 'enter'");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                        }

                        break;
                    case 2:
                        switch (stackNavigation[stackNavigation.Count - 1])
                        {


                            case "Main menu":
                                
                                Clear();
                                stackNavigation.Add("Setting");
                                PrintMenu();
                                break;
                            case "Setting":

                                Console.Clear();
                                Console.WriteLine("Вы действительно хотите сбросить все настройки по умолчанию? Введите: 'y/n' или 'д/н'");
                                string? command = Console.ReadLine().ToLower();
                                if (command == "y" || command == "д")
                                {
                                    Settings.CheckFileSetting(true);
                                }
                                updateArraySetting();
                                Console.Clear();
                                PrintMenu();
                                break;
                        }
                        break;
                    case 3:
                        Clear();
                        stackNavigation.Add("Author");
                        PrintMenu();
                        break;
                    case 4:
                        Clear();
                        stackNavigation.RemoveAt(stackNavigation.Count - 1);
                        switch (stackNavigation[stackNavigation.Count - 1])
                        {
                            case "Main menu":
                                PrintMenu();
                                selectedValue = 1;
                                return false; 
                                default:return true;
                        }

                        
                }
            }
            else
            {
                Clear();
                stackNavigation.RemoveAt(stackNavigation.Count - 1);
                PrintMenu();

            }
            selectedValue = 1;
            return false;
        }

        /// <summary>
        /// Запуск меню
        /// </summary>
        private static void Start()
        {
            ConsoleKeyInfo ki;
            selectedValue = 1;
            AmountElementsInNowMenu = optionsMainMenu.Length;
            PrintMenu();
            WriteCursor(selectedValue);
            bool flagExit = false;
            do
            {

                ki = Console.ReadKey();
                ClearCursor(selectedValue);
                switch (ki.Key)
                {
                    case ConsoleKey.UpArrow:
                        SetUp();
                        break;
                    case ConsoleKey.DownArrow:
                        SetDown();
                        break;
                    case ConsoleKey.W:
                        SetUp();
                        break;
                    case ConsoleKey.S:
                        SetDown();
                        break;
                    #region цифры на клавиатуре
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                        selectedValue = int.Parse(ki.KeyChar.ToString());
                        break;
                    #endregion

                    case ConsoleKey.Enter:
                        flagExit = navigation();
                        break;
                    case ConsoleKey.Escape:
                        navigation("-");
                        if (stackNavigation.Count == 0)
                        {
                            flagExit = true;
                        }
                        break;

                }
                WriteCursor(selectedValue);
            } while (!flagExit);

        }

        private static void Clear()
        {
            Console.Clear();
        }


        /// <summary>
        /// запуск приложения
        /// </summary>
        static public void start()
        {
            Start();

        }

        static private void startServer()
        {
            bool exit = false;
            Console.WriteLine(MyStaticValues.MyStaticBool);
            while (!exit)
            {
                Telegram.SendMessage("введите команду!");
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
                        Telegram.SendMessage("Введите даты. Две даты через пробел, например 2024-09-23 2024-10-28\n если этого не сделать, то по умолчанию будут взята текущая дата");
                        string? data = Console.ReadLine();

                        if (string.IsNullOrEmpty(data))
                        {
                            Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange());
                        }
                        else
                        {
                            var splitDate = data.Split(' ');
                            if (splitDate.Length == 2)
                            {
                                Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange(data.Split(' ')[0], data.Split(' ')[1]));
                            }
                            else
                            {
                                ErrorProcessing.generateTextError($"Вы ввели не правильный формат данных ''{data}'', а требовалось ''2024-09-23 2024-10-28''");
                            }
                        }
                        break;
                    case "":// для быстрого тестирования
                        Telegram.SendMessage("Введите даты. Две даты через пробел, например 2024-09-23 2024-10-28\n если этого не сделать, то по умолчанию будут взята текущая дата");
                        data = Console.ReadLine();
                        data = "1996-01-01 2024-07-21";
                        if (string.IsNullOrEmpty(data))
                        {
                            Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange());
                        }
                        else
                        {
                            var splitDate = data.Split(' ');
                            if (splitDate.Length == 2)
                            {
                                Request.quest("индекс мосбиржи", RequestCommand.QueryGetMoscowExchange(data.Split(' ')[0], data.Split(' ')[1]));
                            }
                            else
                            {
                                ErrorProcessing.generateTextError($"Вы ввели не правильный формат данных ''{data}'', а требовалось ''2024-09-23 2024-10-28''");
                            }
                        }
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
