## Что такое
Боты — специальные аккаунты в Telegram, созданные для того, чтобы автоматически обрабатывать и отправлять сообщения.
Пользователи могут взаимодействовать с ботами при помощи сообщений, отправляемых через обычные или групповые чаты 
Логика бота контролируется при помощи HTTPS запросов к нашему API для ботов.



## Как создать
➔ BotFather — бот управления другими ботами. Предназначен для изменения настроек у существующих ботов и создания новых.
➔ /newbot - создание нового бота
➔ UserName - имя бота, [5-32 символов], должен заканчиваться на «bot»
➔ Токен - строка, которая нужна чтобы получать и отправлять сообщения.
➔ /token - генерирует новый токен

## Запросы
Все запросы к Telegram Bot API должны осуществляться через HTTPS вследующем виде:
```https://api.telegram.org/bot<token>/НАЗВАНИЕ_МЕТОДА```
Все методы регистрозависимы и должны быть в кодировке UTF-8

## Запросы
![Image alt](https://github.com/IlyaGall/C-/blob/main/18%20%D0%97%D0%BD%D0%B0%D0%BA%D0%BE%D0%BC%D1%81%D1%82%D0%B2%D0%BE%20%D1%81%20Telegram%20API/img/1.PNG)

## Что ставить

![Image alt](https://github.com/IlyaGall/C-/blob/main/18%20%D0%97%D0%BD%D0%B0%D0%BA%D0%BE%D0%BC%D1%81%D1%82%D0%B2%D0%BE%20%D1%81%20Telegram%20API/img/2.PNG)

## API

![Image alt](https://github.com/IlyaGall/C-/blob/main/18%20%D0%97%D0%BD%D0%B0%D0%BA%D0%BE%D0%BC%D1%81%D1%82%D0%B2%D0%BE%20%D1%81%20Telegram%20API/img/3.PNG)

![Image alt](https://github.com/IlyaGall/C-/blob/main/18%20%D0%97%D0%BD%D0%B0%D0%BA%D0%BE%D0%BC%D1%81%D1%82%D0%B2%D0%BE%20%D1%81%20Telegram%20API/img/4.PNG)



* [пример бота](https://github.com/rodion-m/ChatGPT_API_dotnet/tree/master/samples/ChatGpt.TelegramBotExample)
* [Документация](https://telegrambots.github.io/book/2/send-msg/text-msg.html)
* [Документация 2](https://core.telegram.org/bots/api#authorizing-your-bot)

## код 

```c#
using Otus.Telegram;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using ClassLibrary1;
using Telegram.Bot.Types.Enums;


var lib = new Calculator();

var catFactory = new CatFactory();
var mapGen = new MapGenerator();
var stateOfChat = new Dictionary<long, ChatMode>();


var ro = new ReceiverOptions
{
    AllowedUpdates = [],
};


var botClient = new TelegramBotClient("7546879526:AAGQRtMeenO42er2H7vFuaJENcFjsW-KU-U"); 
// указание токена

botClient.StartReceiving(
    Handler,
    ErrorHandler,
    ro
    );
// старт соеденения



Console.WriteLine("Startovali");
Console.ReadLine();



async Task Handler(ITelegramBotClient client, Update update, CancellationToken ct)
{
    //if (update.Message != null)
    //{
    //    if (update.Message.Text == "/start")
    //    {
    //        client.SendTextMessageAsync(
    //               update.Message.Chat.Id,
    //               text: $"Приветствую, {update.Message.Chat.LastName}, я буду тебя передразнивать ");
    //    }
    //    else
    //    {
    //        var res = Peredraznit(update.Message.Text!);
    //             client.SendTextMessageAsync(
    //             update.Message.Chat.Id,
    //             text: $"{res}, бебебе");
    //    }
    //}
    if (update.Message == null)
    {
        return;
    }


    //return Task.CompletedTask;
    await client.SendDiceAsync(update.Message!.Chat.Id);
    await client.SendPollAsync(update.Message!.Chat.Id,
        question: "Куда идём мы с пятачком",
        ["Большой", "Большой", "Секрет"]);
    await client.SendContactAsync(
        update.Message!.Chat.Id,
        phoneNumber: "+74957777770",
        firstName: "Спортмастер", lastName: "Петров");


    if (!stateOfChat.TryGetValue(update.Message!.Chat.Id, out var state))
    {
        stateOfChat.Add(update.Message!.Chat.Id, ChatMode.Initial);
    }

    state = stateOfChat[update.Message!.Chat.Id];



    if (update.Message.Text == "/exit")
    {
        stateOfChat[update.Message!.Chat.Id] = ChatMode.Initial;

        await SendMenu(client, update);
    }
    else
    {
        switch (state)
        {
            case ChatMode.Cat:
                await catFactory.Process(client, update, ct);
                break;
            case ChatMode.Map:
                await mapGen.Process(client, update, ct);
                break;
            default:
                switch (update.Message.Text)
                {
                    case "/cat":
                        await catFactory.Process(client, update, ct);
                        stateOfChat[update.Message!.Chat.Id] = ChatMode.Cat;
                        break;
                    case "/map":
                        await mapGen.Process(client, update, ct);
                        stateOfChat[update.Message!.Chat.Id] = ChatMode.Map;
                        break;
                    default:
                        await SendMenu(client, update);
                        break;
                }
                break;
        }


    }


}

string Peredraznit(string input)
{
    var sb = new StringBuilder(input.ToLower());

    for (var i = 0; i < sb.Length; i += 2)
    {
        sb[i] = char.ToUpper(sb[i]);
    }
    return sb.ToString();
}

async Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken ct)
{
    Console.WriteLine("");
}

static Task SendMenu(ITelegramBotClient client, Update update)
{
    return client.SendTextMessageAsync(chatId: update.Message!.Chat.Id,
          text: "Выберите меню:\n\n" +
          "/cat - получение котиков\n" +
          "/map - генерация точки\n" +
          "/exit - вернуться в главное меню");
}

enum ChatMode
{
    Initial = 0,
    Cat = 1,
    Map = 2,
}


```