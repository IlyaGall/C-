using System;
using Otus.Generics.Task.Generics;
using Otus.Generics.Task.Models;
using Otus.Generics.Task.Services;

namespace Otus.Generics.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new Otus.Generics.Task.Generics.MasterSystem();
            var ua = (UserAccount)ms.CreateAccount(new UserAccount
            {
                Login = "IPetrov",
                Firstname = "Иван",
                Lastname = "Петров",
                Created = DateTime.Now,
            });


            var ba = new BigBusinessAccount("Google", "1234");
            ba.Login = "google";
            ba.Created = DateTime.Now;

            ba = (BigBusinessAccount)ms.CreateAccount(ba);


            // Апргрейдим аккаунт до бизнеса
            var privateBa = ms.UpgrageToBusinessAccount<UserAccount, PrivateBussinessAccount>(ua);

            // Выводим его наименование
            ms.PrintBusinessInfo(privateBa);

        }
    }
}
