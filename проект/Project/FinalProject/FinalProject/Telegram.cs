using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups; // кнопки телеграмма в чате
using ScottPlot;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;
using Telegram.Bot.Types.Enums;

//https://telegrambots.github.io/book/index.html документация по telegram


namespace FinalProject
{
    /// <summary>
    /// работа с телеграмм
    /// </summary>
    public class TelegramBotMessage
    {

        /// <summary>
        /// массив кнопок
        /// </summary>
        /// <returns>экземпляр класса InlineKeyboardMarkup с массивом кнопок</returns>
        private static InlineKeyboardMarkup ArrayButton()
        {
            return new InlineKeyboardMarkup(
                new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("справка", "/info"),
                    },
                     new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Список команд", "/ListCommand"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Индекс МБ за 30 дней", "/indexMB30Day"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Индекс МБ за год", "/indexMBYear"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("тестирование ф-и", "test"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Добавить акцию в избранное", "/AddFavorites"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Получить избранные акции", "/GetFavoritesStocks"),
                    },
                }
            );
        }


        public static void startTelegram()
        {
            var botClient = new TelegramBotClient(Settings.GlobalParameters.Token);
            botClient.StartReceiving(clientUpdate, Error);
            Console.WriteLine($"server start. {DateTime.Now}");
            Console.ReadLine();
        }




        /// <summary>
        /// запуск клиента телеграмма
        /// </summary>
        /// <param name="botClient">(ITelegramBotClient) экземпляр интерфейса </param>
        /// <param name="update">обновление записи</param>
        /// <param name="token">отмена операции</param>
        /// <returns></returns>
        async static Task clientUpdate(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var button = update.CallbackQuery;
            if (update.CallbackQuery != null)
            {
                string buttonCommand = update.CallbackQuery.Data;
                long userId = update.CallbackQuery.From.Id;
                Console.WriteLine($"Пользователь {userId} нажал кнопку {buttonCommand}");

                switch (buttonCommand)
                {
                    case "/info":
                        var text = "Список команд:";
                        var getAnswer = Server.ServerCommand(buttonCommand);
                        await botClient.SendTextMessageAsync(userId, $"command: {buttonCommand}\n {getAnswer.Item1}");
                        await botClient.SendTextMessageAsync(userId, text, replyMarkup: ArrayButton());
                        break;
                    case "/ListCommand":
                        text = "Список команд:";
                        await botClient.SendTextMessageAsync(userId, text, replyMarkup: ArrayButton());
                        break;
                    case "/indexMB30Day":
                    case "/indexMBYear":

                    case "test":
                        getAnswer = Server.ServerCommand(buttonCommand);
                        await botClient.SendTextMessageAsync(userId, $"command: {buttonCommand}\n {getAnswer.Item1}");
                        if (getAnswer.Item2 != null)
                        {
                            int stepCollection = 0;
                            foreach (string pathImg in getAnswer.Item2)
                            {
                                if (getAnswer.Item3 != null && getAnswer.Item3[stepCollection] != null)
                                {
                                    await loadPhoto(botClient, userId, pathImg, getAnswer.Item3[stepCollection]);
                                }
                                else
                                {
                                    await loadPhoto(botClient, userId, pathImg, "");
                                }
                            }
                        }
                        break;
                    case "/AddFavorites":
                        text = "Для того чтобы добавить акцию в избранное, нужно написать команду:'/AddFavorites название акции'";
                        await botClient.SendTextMessageAsync(userId, text);
                        break;

                    case "/GetFavoritesStocks":
                        foreach (var nameActive in DataBase.GetStockListUser(userId))
                        {
                            getAnswer = Server.ServerCommand("/GetFavoritesStocks", nameActive);
                            if (getAnswer.Item2 != null)
                            {
                                int stepCollection = 0;
                                foreach (string pathImg in getAnswer.Item2)
                                {
                                    if (getAnswer.Item3 != null && getAnswer.Item3[stepCollection] != null)
                                    {
                                        await loadPhoto(botClient, userId, pathImg, getAnswer.Item3[stepCollection]);
                                        await LoadArrayPhoto(botClient, userId, getAnswer.Item2, getAnswer.Item3);
                                    }
                                    else
                                    {
                                        await loadPhoto(botClient, userId, pathImg, "");
                                        await LoadArrayPhoto(botClient, userId, getAnswer.Item2, null);
                                    }
                                }
                            }
                        }
                        break;

                }
            }

            var message = update.Message;
            if (message != null)
            {
                long userId = message.Chat.Id;
                var messageTelegram = message.Text?.ToString()?.Split(' ');
                switch (messageTelegram[0])
                {
                    case "/AddFavorites":
                        DataBase.addUser(userId);
                        DataBase.AddFavoritesStock(userId, messageTelegram[1]);
                        break;
                    default:
                        await botClient.SendTextMessageAsync(userId, @"Не известная команда! Вызовите \info, чтобы открыть список доступных команд.");
                        break;
                }





                //long IDChats = update.Message.Chat.Id;






                //if (!string.IsNullOrEmpty(message?.Text))
                //{
                //    var s = Server.ServerCommand(message.Text);
                //    Console.WriteLine($"{message.Chat.Username ?? "этот пользователь без имени"} пишет: {message.Text}");
                //    await botClient.SendTextMessageAsync(message.Chat.Id, $"command: {message.Text}\n {s.Item1}");

                //    #region пример с кнопками
                //    /*
                //    var keyboard = new ReplyKeyboardMarkup(new[]
                //     {
                //        new []
                //        {
                //            new KeyboardButton("Хостел"),
                //            new KeyboardButton("Хостел"),
                //            new KeyboardButton("Хостел"),
                //            new KeyboardButton("Контакты"),
                //        },
                //        new []
                //        {
                //            new KeyboardButton("Геолокация"),
                //            new KeyboardButton("Оборудование"),
                //            new KeyboardButton("Оборудование"),
                //            new KeyboardButton("Оборудование"),
                //        }
                //    });
                //    await botClient.SendTextMessageAsync(message.Chat.Id, "О нашем хостеле мы расскажем тут", replyMarkup: keyboard);
                //    await botClient.SendTextMessageAsync(message.Chat.Id, "Removing keyboard", replyMarkup: new ReplyKeyboardRemove());
                //    */
                //    #endregion


                //    var text = "Список команд:";

                //    await botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: ArrayButton());
                //    return;


                //}

                //if (message?.Photo != null)
                //{
                //    await loadFile(botClient, IDChats, "C:\\Users\\Ilya\\Desktop\\falen world\\pero.jpg");
                //    return;
                //}

                if (message.Document != null)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Ща отправим");
                    // var fileId = update.Message.Photo.Last().FileId;
                    var fileId = update.Message.Document.FileId;

                    var fileInfo = await botClient.GetFileAsync(fileId);
                    var filePath = fileInfo.FilePath;

                    string destinationFilePath = $@"C:\\Users\\Ilya\\Desktop\\Новая папка\\" + $"{message.Document.FileName}";

                    await using Stream fileStream = System.IO.File.Create(destinationFilePath);
                    await botClient.DownloadFileAsync(
                        filePath: filePath,
                        destination: fileStream);
                    fileStream.Close();



                    //отправка файла
                    string fileName = "PEROOOOOO.jpg";
                    await using Stream stream = System.IO.File.OpenRead("C:\\Users\\Ilya\\Desktop\\falen world\\pero.jpg");
                    var messageLoad = await botClient.SendDocumentAsync(
                        message.Chat.Id,
                        document: InputFile.FromStream(stream, fileName),
                        caption: "The Tragedy of Hamlet,\nPrince of Denmark");


                    return;
                }
            }
        }

        /// <summary>
        /// ф-ция отправки документа клиенту
        /// </summary>
        /// <param name="botClient">(ITelegramBotClient) экземпляр интерфейса </param>
        /// <param name="IDChats">(long) id чата пользователя</param>
        /// <param name="pathFile">(string) путь до файла</param>
        /// <param name="text">(string) Текст если требуется</param>
        /// <returns></returns>
        private static async Task loadFile(ITelegramBotClient botClient, long IDChats, string pathFile, string text = "")
        {

            string fileName = pathFile.Remove(0, pathFile.LastIndexOf('\\') - 1);// "PEROOOOOO.jpg";
            await using Stream stream = System.IO.File.OpenRead(pathFile);
            var messageLoad = await botClient.SendDocumentAsync(
                IDChats,
                document: InputFile.FromStream(stream, fileName),
                caption: $"{text}");
        }

        /// <summary>
        /// ф-ция отправки фотографии клиенту
        /// </summary>
        /// <param name="botClient">(ITelegramBotClient) экземпляр интерфейса </param>
        /// <param name="IDChats">(long) id чата пользователя</param>
        /// <param name="pathFile">(string) путь до файла</param>
        /// <param name="text">(string) Текст если требуется</param>
        /// <returns></returns>
        private static async Task loadPhoto(ITelegramBotClient botClient, long IDChats, string pathFile, string text = "12121212")
        {
            string fileName = pathFile.Remove(0, pathFile.LastIndexOf('\\') - 1);// "PEROOOOOO.jpg";
            await using Stream stream = System.IO.File.OpenRead(pathFile);

            var messageLoad = await botClient.SendPhotoAsync(
                  chatId: IDChats,
                  photo: InputFile.FromStream(stream, fileName),
                  caption: $"{text}"
                );

        }


        /// <summary>
        /// тестовая ф-я отправки сообщения с n количеством картинок
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="IDChats"></param>
        /// <param name="pathFile"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static async Task LoadArrayPhoto(ITelegramBotClient botClient, long IDChats, List <string> pathFile, List<string> text )
        {
            List<FileStream> streams = new List<FileStream>();
            List<InputMediaPhoto> phots = new List<InputMediaPhoto>();
            bool addText = false;
            StringBuilder stringBuilder = new () ;
            foreach (string item in text ) 
            {
                stringBuilder.AppendLine(item );
            }
            try
            {
                foreach (string p in pathFile)
                {
                    FileStream s = System.IO.File.OpenRead(p);
                    streams.Add(s);
                    phots.Add(new InputMediaPhoto(InputFile.FromStream(s, Path.GetFileName(p)))
                    { 
                        Caption = !addText ? $"{stringBuilder.ToString()}" :"" }
                    );
                    addText = true;
                    //phots.Add(new InputMediaPhoto(new InputFile(s, Path.GetFileName(p))));
                }
               
                await botClient.SendMediaGroupAsync(IDChats, phots);

            }
            catch (Exception ex)
            {
                //TODO
            }
            finally
            {
                foreach (var s in streams)
                    s.Dispose();
                phots.Clear();
            }
        }


        private static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine(exception.Message);
            throw new NotImplementedException();
        }





      

        /// <summary>
        /// отправка пользователю сообщения
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessage(string message)
        {
            //пока поставлю заглушку, в виде writeline
            Console.WriteLine(message);

        }

        /// <summary>
        /// отправка сообщения разработчику о том, чтобы посмотрел что-же пошло не так и подробное описание
        /// </summary>
        /// <param name="message"></param>
        static public void SendMessageDebagger(string message)
        {
            Console.WriteLine(message);
        }
    }
}
