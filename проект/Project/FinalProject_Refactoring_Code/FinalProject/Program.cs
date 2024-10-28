using System.Net;
using System.Xml;
using System.Reflection;
using ScottPlot;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using SettingsFinalProject;

namespace FinalProject
{
 
    internal class Program
    {
        static void Main(string[] args)
        {
          
            //  MethodLineSupport.lineSupport();
            //  return;
            // Telegram.startTelegram();
            //  test();
            //  return;
            //
            Settings.CheckFileSetting();
            ErrorProcessing.start();
         

        }

        static private void test()
        {
            ScottPlot.Plot myPlot = new();
            

            
            DateTime timeOpen = new(2024, 01, 03, 9, 30, 0); // 9:30 AM
            DateTime timeClose = new(2024, 01, 03, 10, 10, 0); // 4:00 PM
            TimeSpan timeSpan = TimeSpan.FromMinutes(10); // 10 minute bins

            // <row open="271.9" close="271.9" high="271.9" low="271.9"
            // value="48251374" volume="177460" begin="2024-01-03 09:50:00"
            // end="2024-01-03 09:59:59"/>
            double[] open = new double[5] { 275, 275.08 , 274.8,273.62, 274.01 };
            double[] close = new double[5] { 275, 274.85, 273.62, 274.01, 274.46 };
            double[] high = new double[5] { 275, 275.56, 275.28, 274.25 , 274.97 };
            double[] low = new double[5] { 275, 274.35, 273.45, 273.5, 273.95 };
            List<OHLC> prices = new();
            int step = 0;
            for (DateTime dt = timeOpen; dt <= timeClose; dt += timeSpan)
            {
                //double open = Generate.RandomNumber(20, 40) + prices.Count;
                //double close = Generate.RandomNumber(20, 40) + prices.Count;
                //double high = Math.Max(open, close) + Generate.RandomNumber(5);
                //double low = Math.Min(open, close) - Generate.RandomNumber(5);
                prices.Add(new OHLC(open[step], high[step], low[step], close[step], dt, timeSpan));
                step++;
            }

            myPlot.Add.Candlestick(prices);
            myPlot.Axes.DateTimeTicksBottom();


            myPlot.SavePng("C:\\Users\\Ilya\\Desktop\\ыфвыф\\demo.png", 400, 300);
        }
    }
}
