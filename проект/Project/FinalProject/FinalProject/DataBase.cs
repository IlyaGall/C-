using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface DateBase
    {
        /// <summary>
        /// добавить пользователя в бд пользователя
        /// </summary>
        /// <returns>true успешно или нет</returns>
        public bool addUser();

        /// <summary>
        /// добавить акции в избранное
        /// </summary>
        /// <returns></returns>
        public string AddStock();

        /// <summary>
        /// поиск акции
        /// </summary>
        /// <returns></returns>
        public string SearchStock();

        /// <summary>
        /// вернуть все избранные активы пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetStockListUser(long id);
    }
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
