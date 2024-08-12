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

//https://telegrambots.github.io/book/index.html документация по telegram


namespace FinalProject
{
    /// <summary>
    /// работа с телеграмм
    /// </summary>
    public class Telegram
    {

        public static void startTelegram()
        {
            var botClient = new TelegramBotClient("7464125156:AAHqimIk5c3Sh5z2L-pu6txlpup9ZZ6M7-k");
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
            var message = update.Message;
            long IDChats = update.Message.Chat.Id;

            if (!string.IsNullOrEmpty(message?.Text))
            {
   //             Server.test(message.Text);
              string s =  Server.ServerCommand(message.Text);

                Console.WriteLine($"{message.Chat.Username ?? "этот пользователь без имени"} пишет: {message.Text}");
                //if (message.Text.ToLower().Contains("h"))
                //{
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"command: {message.Text}\n {s}");
                // using Telegram.Bot.Types.ReplyMarkups;

                var keyboard = new ReplyKeyboardMarkup(new[]
                 {
                    new []
                    {
                        new KeyboardButton("Хостел"),
                        new KeyboardButton("Хостел"),
                        new KeyboardButton("Хостел"),
                        new KeyboardButton("Контакты"),
                    },
                    new []
                    {
                        new KeyboardButton("Геолокация"),
                        new KeyboardButton("Оборудование"),
                        new KeyboardButton("Оборудование"),
                        new KeyboardButton("Оборудование"),
                    }
                });
                await botClient.SendTextMessageAsync(message.Chat.Id, "О нашем хостеле мы расскажем тут", replyMarkup: keyboard);
                await botClient.SendTextMessageAsync(message.Chat.Id, "Removing keyboard", replyMarkup: new ReplyKeyboardRemove());
                return;
                //}

            }
            if (message?.Photo != null)
            {
                await loadFile(botClient, IDChats, "C:\\Users\\Ilya\\Desktop\\falen world\\pero.jpg");
                return;
            }

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

        /// <summary>
        /// ф-ция отправки фото клиенту
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




        private static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }





        /// <summary>
        /// вытащить путь к картинкам в сообщении
        /// </summary>
        /// <returns></returns>
        static private string[]? parsingPath(string message) 
        {
            string[] pathImg = message.Split('~');
            return null;
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
