using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTelegram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("6665845214:AAFbqxiEXtCziYXD_dU21AAq3zklTbYDEtA");
            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
            cts.Cancel();
        }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            switch (messageText)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Привет! Я бот. Как я могу помочь?",
                        cancellationToken: cancellationToken);
                    break;

                case "/image":
                    using (var stream = new FileStream("C:\\Users\\619se\\OneDrive\\Изображения\\Без названия.jpg", FileMode.Open))
                    {
                        await botClient.SendPhotoAsync(
                            chatId: chatId,
                            photo: new InputFileStream(stream),
                            caption: "Ваша картинка",
                            cancellationToken: cancellationToken);
                    }
                    break;

                case "/video":
                    using (var stream = new FileStream("C:\\Users\\619se\\OneDrive\\Изображения\\Rick Roll (Different link + no ads).mp4", FileMode.Open))
                    {
                        await botClient.SendVideoAsync(
                            chatId: chatId,
                            video: new InputFileStream(stream),
                            caption: "Ваше видео",
                            cancellationToken: cancellationToken);
                    }
                    break;

                case "/sticker":
                    Message message1 = await botClient.SendStickerAsync(
                    chatId: chatId,
                    sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"),
                    cancellationToken: cancellationToken);
                    break;
                case "/buton":
                    var keyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Ответ 1"),
                            new KeyboardButton("Ответ 2")
                        }
                    });
                    Message sentMessage = await botClient.SendTextMessageAsync(
                       chatId: chatId,
                       text: "Выберите один из вариантов:",
                       replyMarkup: keyboard,
                       cancellationToken: cancellationToken
                    );
                    break;

                default:
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Вы сказали:\n" + messageText,
                        cancellationToken: cancellationToken);
                    break;
            }
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error: \n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(errorMessage);
            return Task.CompletedTask;
        }
    }
}
