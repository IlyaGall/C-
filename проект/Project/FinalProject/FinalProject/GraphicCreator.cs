using ScottPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class GraphicCreator
    {

        /// <summary>
        /// удаление всех файлов после завершения ссесии
        /// </summary>
        static public void DelAllIMGInTemp() 
        {
        
        }
   

        /// <summary>
        /// построение графика Время - x, диапазон чисел y
        /// </summary>
        /// <param name="directory">пусть сохранения картинки</param>
        /// <param name="nameFile">название файла</param>
        /// <param name="date">массив дат</param>
        /// <param name="value">массив значений</param>
        static public void GraphicCreatorDateTime(string directory ,string nameFile, DateTime[] date, double[] value)
        {
            ScottPlot.Plot myPlot = new();
            DateTime[] dateTimes = new DateTime[date.Length];
            for (int i = 0; i < date.Length; i++)
            {
                dateTimes[i] = Convert.ToDateTime(date[i]);
            }
            myPlot.Add.Scatter(dateTimes, value); // x , y
            myPlot.Axes.DateTimeTicksBottom();
            myPlot.Axes.Right.MinimumSize = 50;

            myPlot.SavePng($"{directory}\\{nameFile}", Settings.GlobalParameters.WITH_IMG,Settings.GlobalParameters.HEIHG_IMG);
        }

    }
}
