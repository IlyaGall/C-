using ScottPlot.Colormaps;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ScottPlot;
using System.Resources;


namespace FinalProject
{
    /// <summary>
    /// класс настроек проекта
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Проверка пути, который хочет указать пользователь
        /// </summary>
        /// <param name="NewPath">Путь который нужно проверить</param>
        /// <returns></returns>
        public static bool CorrectPathDirectory(string NewPath)
        {
            if (string.IsNullOrEmpty(NewPath))
            {
                GlobalParameters.Error = "Пустая строчка";
                return false;
            }

            if (!exitsFolder(NewPath))
            {
                GlobalParameters.Error = "не получилось создать/найти папку";
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// проверить на существование директории в случае её отсутствия создать папку
        /// </summary>
        static private bool exitsFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    if (path.Split('\\').Length <= 1) { return false; }
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// проверка, что директория и файл существуют в системе
        /// </summary>
        /// <param name="replaceFileSettings">сбросить настройки по умолчанию (false)</param>
        static public void CheckFileSetting(bool replaceFileSettings = false)
        {
            string filename = "setting.json";
            string path = Directory.GetCurrentDirectory();
            if (!Directory.Exists(path + "/setting"))
            {
                Directory.CreateDirectory(path + "/setting");
            }
            if (!File.Exists(path + "\\setting\\" + filename))
            {
                saveSetting(path + "\\setting\\" + filename);
            }
            if (replaceFileSettings)
            {
                saveSetting(path + "\\setting\\" + filename);
            }
            else
            {
                loadSetting(path + "\\setting\\" + filename);
            }
        }

        /// <summary>
        /// Класс хранящий настройки
        /// </summary>
        private class SettingJson
        {
            /// <summary>
            /// Версия ПО
            /// </summary>
            public string Version { get; }
            /// <summary>
            /// Путь до файла настроек
            /// </summary>
            public string Path { get; set; }
            /// <summary>
            /// Размер картинки (ширина) при формировании графиков
            /// </summary>
            public string With { get; set; }
            /// <summary>
            /// Размер картинки (высота) при формировании графиков
            /// </summary>
            public string Height { get; set; }
            /// <summary>
            /// Токен TelegramBot, храниться в файле настроек
            /// </summary>
            public string Token { get; set; }
            /// <summary>
            /// Отображаемый интервал между свечками(дни, часы)
            /// </summary>
            public string CandleInterval { get; set; }
            /// <summary>
            /// Конструктор настроек 
            /// </summary>
            /// <param name="version">Версия ПО</param>
            /// <param name="path">Путь до файла настроек</param>
            /// <param name="with">Размер картинки (ширина) при формировании графиков</param>
            /// <param name="height">Размер картинки (высота) при формировании графиков</param>
            /// <param name="token">Токен TelegramBot, храниться в файле настроек</param>
            /// <param name="candleInterval">Отображаемый интервал между свечками(дни, часы)</param>
            public SettingJson(string version, string path, string with, string height, string token, string candleInterval)
            {
                Version = version;
                Path = path;
                With = with;
                Height = height;
                Token = token;
                CandleInterval = candleInterval;
            }

        }

        /// <summary>
        /// Сохранение файла настроек
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        static private void saveSetting(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                SettingJson setting = new SettingJson(
                    GlobalParameters.VersionProgram,
                    GlobalParameters.PathSave,
                    GlobalParameters.WithIMG.ToString(),
                    GlobalParameters.HeightIMG.ToString(),
                    GlobalParameters.Token,
                    GlobalParameters.CandleInterval
                    );
                JsonSerializer.Serialize<SettingJson>(fs, setting);
            }
        }

        /// <summary>
        /// Загрузка файла настроек
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        static private void loadSetting(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var settingJson = JsonSerializer.Deserialize<SettingJson>(fs);
                GlobalParameters.PathSave = settingJson.Path;
                GlobalParameters.VersionProgram = settingJson.Version;
                GlobalParameters.WithIMG = int.Parse(settingJson.With);
                GlobalParameters.HeightIMG = int.Parse(settingJson.Height);
                GlobalParameters.Token = settingJson.Token;
                GlobalParameters.CandleInterval = settingJson.CandleInterval;
            }
        }

        /// <summary>
        /// Настройки по умолчанию
        /// </summary>
        public static class GlobalParameters
        {
            public static string VersionProgram = "1.0.0.0";
            public static string PathSave = @"C:\Users\Ilya\Desktop\ыфвыф";
            public static string Avtar = "ENG: Ilay Galuzinskiy          RU: Илья Галузинский\n" +
                                         "#########################################################\n" +
                                         "ENG:You can contact me:        RU: Связаться со мной можно:\n" +
                                         "Telegram: IlyaGaluzinskiy      Телеграмм: IlyaGaluzinskiy \n" +
                                         "Gmail: ilyagall01@gmail.com    Почта: ilyagall01@gmail.com\n";
            public static string Error = "Error";
            public static int WithIMG = 400;
            public static int HeightIMG = 300;
            public static string Token = "";
            public static string CandleInterval = "1";


            /*
            пришлось ставить пакет draving common от этой фичи наверное нужно избавиться)
             */
            public static void Images()
            {
                Bitmap bitmap = Resource1.Logo50;

                // Вычисляем ширину и высоту консоли
                int consoleWidth = Console.WindowWidth - 1;
                int consoleHeight = Console.WindowHeight - 1;

                // Определяем ширину и высоту блока пикселей,
                // которые будут заменены одним символом в консоле.
                int blockWidth = bitmap.Width / consoleWidth;
                int blockHeight = bitmap.Height / consoleHeight;


                // Пройдемся по каждому блоку пикселей
                for (int y = 0; y < bitmap.Height; y += blockHeight)

                {
                    for (int x = 0; x < bitmap.Width; x += blockWidth)
                    {

                        // вычислим среднюю интенсивность пискелей в этом блоке
                        int totalIntensity = 0;
                        int pixelCount = 0;
                        for (int j = 0; j < blockHeight; j++)
                        {
                            for (int i = 0; i < blockWidth; i++)
                            {
                                int px = x + 4;
                                int py = y + j;
                                if (px >= bitmap.Width)
                                {
                                    px = bitmap.Width - 1;
                                }
                                if (py >= bitmap.Height)
                                { py = bitmap.Height - 1; }
                                System.Drawing.Color color = bitmap.GetPixel(px, py);
                                int intensity = (color.R + color.G + color.B) / 3;
                                totalIntensity += intensity;
                                pixelCount++;
                            }
                        }


                        int averageIntensity = totalIntensity / pixelCount;

                        // ByGepem cumeon ana npeactasnexna store
                        // Gnoka B 3aBCUMOCTH OT ero MHTeHCHBHOCTH
                        char character;

                        if (averageIntensity < 25)
                        { character = '@'; }
                        if (averageIntensity < 50)
                        { character = '#'; }
                        else if (averageIntensity < 75)
                        { character = '&'; }
                        else if (averageIntensity < 100)
                        { character = '$'; }
                        else if (averageIntensity < 125)
                        {
                            character = '*';
                        }
                        else if (averageIntensity < 150)
                        {
                            character = '0';
                        }
                        else if (averageIntensity < 175)
                        { character = ':'; }
                        else if (averageIntensity < 200)
                        {
                            character = '.';
                        }
                        else
                        {
                            character = ' ';
                        }

                        // YcTaHoBwM yBeT KOHCONM B 3aBMCMMOCTH OT MHTeHCHBHOCTH
                        ConsoleColor consoleColor;

                        if (averageIntensity < 25)

                        {
                            consoleColor = ConsoleColor.White;
                        }
                        else if (averageIntensity < 50)
                        { consoleColor = ConsoleColor.Gray; }
                        else if (averageIntensity < 75)
                        {
                            consoleColor = ConsoleColor.DarkGray;
                        }
                        else if (averageIntensity < 100)
                        { consoleColor = ConsoleColor.DarkYellow; }
                        else if (averageIntensity < 125)
                        { consoleColor = ConsoleColor.Yellow; }
                        else if (averageIntensity < 150)
                        { consoleColor = ConsoleColor.DarkGreen; }
                        else if (averageIntensity < 175)
                        { consoleColor = ConsoleColor.Green; }
                        else if (averageIntensity < 200)
                        { consoleColor = ConsoleColor.DarkBlue; }

                        else
                        {

                            consoleColor = ConsoleColor.Blue;
                        }

                        Console.ForegroundColor = consoleColor;

                        // Hapucyem cumeon ana Toro 6noKa
                        Console.Write(character);


                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

