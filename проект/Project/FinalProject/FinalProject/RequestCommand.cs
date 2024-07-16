using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    ///https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/imoex.xml?iss.meta=off&iss.only=history&history.columns=CLOSE,TRADEDATE
    //?iss.meta=off - отключение метаданных они не нужны
    //&iss.only=history  - оставить только один блок history
    //&history.columns=CLOSE,TRADEDATE -вывести определённые колонки
    static class RequestCommand
    {
        /// <summary>
        /// вспомогательный метод для расчёта даты
        /// </summary>
        static private string dateTime(int day = 0) 
        {
           return DateTime.Now.AddDays(day).ToString("yyyy-MM-dd");
          
        }



        static public string info()
        {
            string returnS = $"/command QUERYLastPrice вернуть последнюю цену по акциям\n" +
                $"/command QUERY2 вернуть последнюю цену по акциям расширенное наименование\n" +
                $"/command QuerySearchName \n" +
                $"/command QueryCandle вернуть свечи\n" +
                $"/command QueryStatisticAll вернуть все акции\n";


            return returnS;
        }

        // https://iss.moex.com/iss/reference/ список запросов
        static public string QUERYLastPrice()
        {
            /// <summary>
            /// вернуть последнюю цену по всем акциям
            /// </summary>
            string lastPrice = "https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities.xml?iss.meta=off&iss.only=marketdata&marketdata.columns=SECID,LAST";
            return lastPrice;
        }//

        static public string QUERY2()
        {
            /// <summary>
            /// вернуть последнюю цену по всем акциям + наименование полное
            /// </summary> //http://iss.moex.com/iss/history/engines/stock/markets/shares/boards/TQBR/securities.json
            string lastPrice = "https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities.xml?iss.meta=off&iss.only=marketdata&marketdata.columns=BOARDID,TRADEDATE,SHORTNAME,SECID,NUMTRADES,VALUE,OPEN,LOW,HIGH,LEGALCLOSEPRICE,WAPRICE,CLOSE,VOLUME,MARKETPRICE2,MARKETPRICE3,ADMITTEDQUOTE,MP2VALTRD,MARKETPRICE3TRADESVALUE,ADMITTEDVALUE,WAVAL,TRADINGSESSION,CURRENCYID,TRENDCLSPR";
            return lastPrice;
        }
        /// <summary>
        /// вернуть значения выбранной акции
        /// </summary>
        /// <param name="nameLot">название актива </param>
        /// <returns></returns>
        static public string QuerySearchName(string nameLot = "SBER")
        {
            return $@"http://iss.moex.com/iss/history/engines/stock/markets/shares/boards/TQBR/securities/{nameLot}.json";
            //return "https://iss.moex.com/iss/securities.json?q=Yandex" ;

        }
        /// <summary>
        /// получение свечи
        /// </summary>
        /// <param name="nameActive">название актива, например SBER</param>
        /// <param name="dataStart">дата начала торгов (год-месяц-день)</param>
        /// <param name="dataEnd">дата конца торгов (год-месяц-день)</param>
        /// <param name="interval">интервал свечи (минуты)</param>
        /// 
        /// <returns></returns>
        static public string QueryCandle(string nameActive = "SBER", string dataStart = "2024-01-01", string dataEnd = "2024-01-30", string interval = "10")
        {
            /*
            читаем описание в котором сказано, что url строится по шаблону / iss / engines / [engine] / markets / [market] / securities / [security] / candles и описаны дополнительные параметры. Строим ссылку, например (с выводом в json):
            http://iss.moex.com/iss/engines/stock/markets/shares/securities/SBER/candles.json?from=2021-01-01&till=2021-01-30&interval=10
            Данные для свечей по Сбербанку с 1 по 30 января 2021 получены.
            */
            
            return $@"http://iss.moex.com/iss/engines/stock/markets/shares/securities/{nameActive}/candles.json?from={dataStart}&till={dataEnd}&interval={interval}";
        }

        /// <summary>
        /// вернуть все текущие цены по акциям
        /// </summary>
        /// <returns></returns>
        static public string QueryStatisticAll()
        {
            return @"http://iss.moex.com/iss/history/engines/stock/markets/shares/boards/TQBR/securities.json";
        }

        /// <summary>
        /// получить акции с наименованием и тикером для заполнения БД
        /// </summary>
        /// <returns></returns>
        static public string QueryGetAllAction()
        {
            // оригинальный запрос https://iss.moex.com/iss/engines/stock/markets/shares/boards/tqbr/securities.xml
            // return @"https://iss.moex.com/iss/engines/stock/markets/shares/boards/tqbr/securities.json?iss.meta=off&iss.only=securities&securities.columns=SECID,PREVPRICE,SHORTNAME";
            return @"https://iss.moex.com/iss/engines/stock/markets/shares/boards/tqbr/securities.xml?iss.meta=off&iss.only=securities&securities.columns=SECID,PREVPRICE,SHORTNAME";
        }







        /// <summary>
        /// вернуть индекс московской биржи(за 30 дней)
        /// </summary>
        /// <returns></returns>
        static public string QueryGetMoscowExchange() 
        {
            string dataStart = dateTime(-30);
            string dataEnd = dateTime();
            return $@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/imoex.xml?iss.meta=off&iss.only=history&history.columns=CLOSE,TRADEDATE&from={dataStart}&till={dataEnd}";


        }

        /// <summary>
        /// индекс мосбиржи
        /// </summary>
        /// <param name="dataStart">дата начала</param>
        /// <param name="dataEnd">дата окончания</param>
        /// <returns></returns>
        static public string QueryGetMoscowExchange(string dataStart = "2024-01-01", string dataEnd = "2024-01-30")
        {
           
            //https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/imoex.xml?iss.meta=off&iss.only=history&history.columns=CLOSE,TRADEDATE&from=2024-01-01&till=2024-01-30
            return $@"https://iss.moex.com/iss/history/engines/stock/markets/index/boards/SNDX/securities/imoex.xml?iss.meta=off&iss.only=history&history.columns=CLOSE,TRADEDATE&from={dataStart}&till={dataEnd}";
        }

    }
}
