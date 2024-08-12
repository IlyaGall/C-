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
        /// <summary>
        /// Обновление раздела настроек 
        /// </summary>
        private static string[] settings = new[] {
            $"Временное хранение файлов графиков '{Settings.GlobalParameters.PATH_SAVE}'",
            $"Сбросить файл настроек по умолчанию",
            $"Версия по '{Settings.GlobalParameters.VERSION_PROGRAM}'",
            $"Ширина картинки = {Settings.GlobalParameters.WITH_IMG}",
            $"Высота картинки = {Settings.GlobalParameters.HEIHG_IMG}",
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
            $"Ширина картинки = {Settings.GlobalParameters.WITH_IMG}",
            $"Высота картинки = {Settings.GlobalParameters.HEIHG_IMG}",
            "Выход в меню"
            };

        }

        /// <summary>
        /// возвращаем фичу
        /// </summary>
        private static string[] author = new[] {
            $"Автор ПО '{Settings.GlobalParameters.AVTOR}'",
        };

        /// <summary>
        /// навигация по меню
        /// </summary>
        /// <param name="movement">в какую строну движение + вперёд</param>
        /// <returns>bool try если дошли до конца пути</returns>
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
                            Telegram.startTelegram();
                           // Server.ServerStart();
                            Clear();
                            PrintMenu();
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
                                string? command = Console.ReadLine()?.ToLower();
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
                      
                        switch (stackNavigation[stackNavigation.Count - 1])
                        {
                            case "Main menu":
                                stackNavigation.RemoveAt(stackNavigation.Count - 1);
                                PrintMenu();
                                selectedValue = 1;
                                return true;
                            case "Setting":
                                Console.Clear();
                                Console.WriteLine("Ведите новую ширину");

                                if (int.TryParse(Console.ReadLine(), out var with))
                                {
                                    Settings.GlobalParameters.WITH_IMG = with;
                                    updateArraySetting();
                                    Settings.CheckFileSetting(true);
                                    Console.Clear();
                                }
                                else 
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Внимание не удалось преобразовать {with} в целочисленное число. Сброшено на дефолтные значения.{Settings.GlobalParameters.ERROR}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                PrintMenu();
                                break;
                             
                            default:
                                return true;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Ведите новую высоту");
                        if (int.TryParse(Console.ReadLine(), out var heigh))
                        {
                            Settings.GlobalParameters.HEIHG_IMG = heigh;
                            updateArraySetting();
                            Settings.CheckFileSetting(true);
                            Console.Clear();
                        }
                        else 
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Внимание не удалось преобразовать {heigh} в целочисленное число. Сброшено на дефолтные значения.{Settings.GlobalParameters.ERROR}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        PrintMenu();
                        break;
                    case 6:
                        Console.Clear();
                        stackNavigation.RemoveAt(stackNavigation.Count - 1);
                        PrintMenu();
                        selectedValue = 1;
                        return false;
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
    }
}
