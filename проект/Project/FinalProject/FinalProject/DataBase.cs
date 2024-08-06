using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    //логика работы с БД
    public class DataBase
    {
        public class DataStock
        {

            private double _prevprice;
            public string? SECID { get; set; }
            public double PREVPRICE
            {
                get => _prevprice;
                set
                {
                    try
                    {
                        _prevprice = Convert.ToDouble(value.ToString().Replace(".", ","));
                    }
                    catch
                    {
                        throw new Exception("нельзя конвертировать! Разбирайся с запросом!");
                    }
                }
            }
            public string? SHORTNAME { get; set; }





        }

        /// <summary>
        /// добавить акцию
        /// </summary>
        public void Add()
        {

        }
    }
}
