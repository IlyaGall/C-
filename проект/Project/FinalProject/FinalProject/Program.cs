using System.Net;
using System.Xml;
using System.Reflection;
using ScottPlot;
using System.Runtime.InteropServices;

namespace FinalProject
{
 
    internal class Program
    {

        static void Main(string[] args)
        {
            // Telegram.startTelegram();
            // test();
            //  return;
            //
            Settings.CheckFileSetting();
            ErrorProcessing.start();
         

        }

        static private void test()
        {
            ScottPlot.Plot myPlot = new();
            DateTime timeOpen = new(2024, 01, 03, 9, 30, 0); // 9:30 AM
            DateTime timeClose = new(2024, 01, 03, 16, 0, 0); // 4:00 PM
            TimeSpan timeSpan = TimeSpan.FromMinutes(10); // 10 minute bins
            
            // <row open="271.9" close="271.9" high="271.9" low="271.9"
            // value="48251374" volume="177460" begin="2024-01-03 09:50:00"
            // end="2024-01-03 09:59:59"/>

            List<OHLC> prices = new();
            for (DateTime dt = timeOpen; dt <= timeClose; dt += timeSpan)
            {
                double open = Generate.RandomNumber(20, 40) + prices.Count;
                double close = Generate.RandomNumber(20, 40) + prices.Count;
                double high = Math.Max(open, close) + Generate.RandomNumber(5);
                double low = Math.Min(open, close) - Generate.RandomNumber(5);
                prices.Add(new OHLC(open, high, low, close, dt, timeSpan));
            }

            myPlot.Add.Candlestick(prices);
            myPlot.Axes.DateTimeTicksBottom();


            myPlot.SavePng("C:\\Users\\Ilya\\Desktop\\ыфвыф\\demo.png", 400, 300);
        }
    }
}
