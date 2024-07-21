using ScottPlot.Colormaps;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal static class Settings
    {
        public static class GlobalParameters
        {
            public static string VERSION_PROGRAM = "1.0.0.0";
            public static string PATH_SAVE = @"C:\Users\Ilya\Desktop\ыфвыф"; 
            public static string AVTOR = "ENG: Ilay Galuzinskiy          RU: Илья Галузинский\n" +
                                         "#########################################################\n" +
                                         "ENG:You can contact me:        RU: Связаться со мной можно:\n" +
                                         "Telegram: IlyaGaluzinskiy      Телеграмм: IlyaGaluzinskiy \n" +
                                         "Gmail: ilyagall01@gmail.com    Почта: ilyagall01@gmail.com\n";

            /*
            пришлось ставить пакет draving common от этой фичи наверное нужно избавиться)
             */
            public static void Images()
            {

                // Путь до изображения
                string imagePath = @"C:\\Users\\Ilya\\Desktop\\kak_vygliadit_cherepakha_risunok_54.png";

                // Загружаем изображение
               Bitmap bitmap = new Bitmap(imagePath);

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
                                Color color = bitmap.GetPixel(px, py);
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

      