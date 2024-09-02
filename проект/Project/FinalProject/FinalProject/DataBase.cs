using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FinalProject
{


    interface IDateBase
    {
        /// <summary>
        /// добавить пользователя в бд пользователя
        /// </summary>
        /// <returns>true успешно или нет</returns>
        public bool addUser(long idUser);

      /// <summary>
      /// вернуть избранные акции пользователем
      /// </summary>
      /// <param name="idUser">id пользователя</param>
      /// <param name="nameStock">название акции</param>
      /// <returns></returns>
        public bool AddFavoritesStock(long idUser, string nameStock);

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
        static List<long> Users = new();
        static List<string> FavoritesStock = new() { "SBER", "LKOH" };

        /// <summary>
        /// пользователя
        /// </summary>
       static public bool addUser(long idUser)
        {
            if (Users.Contains(idUser))
            {
               return false;
            }
            else 
            {
                Users.Add(idUser);
                return true;
            }
        }

        static public bool AddFavoritesStock(long idUser, string nameStock)
        {
            if (FavoritesStock.Contains(nameStock))
            {
                return false;
            }
            else
            {
                FavoritesStock.Add(nameStock);
                return true;
            }
        }

        public string SearchStock()
        {
            throw new NotImplementedException();
        }

        static public List<string> GetStockListUser(long idUser)
        {
            //TODO: пока сделаю так потом поменять на работу с бд через связи
            //if (Users.Contains(idUser))
            //{
                List<string> itemsStock = new();
                foreach (var item in FavoritesStock)
                {
                    itemsStock.Add(item);
                }
                return itemsStock;
           // }
           // else
           // {
                
            //    return null;
           // }
        }
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
    }

  
}
