using System;
using System.Collections.Generic;
using System.Linq;
using Otus.Generics.Task.Models;
using Otus.Generics.Task.Services;

namespace Otus.Generics.Task.Generics
{
    public class MasterSystem
    {

        private List<BaseAccount> _accounts = new List<BaseAccount>();

        /// <summary>
        /// Базовый инкримент для данных
        /// </summary>
        private int _idIncreement = 1;


        /// <summary>
        /// Создает Аккаунт
        /// </summary>
        /// <param name="newAccountInfo">Информация об аккаунте</param>
        /// <returns></returns>
        public BaseAccount CreateAccount(T newAccountInfo)
        {
            if (_accounts.Any(x => x.Login == newAccountInfo.Login))
            {
                throw new System.Exception($"Account {newAccountInfo.Login} exists");
            }

            newAccountInfo.Id = _idIncreement++;
            newAccountInfo.Created = DateTime.Now;

            _accounts.Add(newAccountInfo);

            MyConsole.WriteLine($"Created Account login={newAccountInfo.Login} id={newAccountInfo.Id}");
            return newAccountInfo;
        }

        /// <summary>
        /// На основе аккаунта пользователя создает аккаунт 
        /// </summary>
        /// <param name="account"></param>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <returns></returns>
        public TTo UpgrageToBusinessAccount<TFrom, TTo>(
             TFrom account)
             where TTo : BaseAccount
        {
            var ba = new TTo();
            ba.Login = Guid.NewGuid().ToString().Replace("-", "");
            ba.UpdateFromUserAccount(account);
            ba.Created = DateTime.Now;
            ba.Id = _idIncreement++;
            _accounts.Add(ba);
            MyConsole.WriteLine($"Created business account newlogin={ba.Login} newId={ba.Id} from login={account.Login} {account.Firstname} {account.Lastname}");
            return ba;
        }

        /// <summary>
        /// Выводим официальное название бизнес-аккаунта
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <typeparam name="K"></typeparam>
        public void PrintBusinessInfo<K>(K account)
        {
            MyConsole.WriteLine(account.GetPrintName());
        }
    }
}