﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;

namespace LibraryBot
{
    public sealed class TelegramBot
    {
        private ITelegramBotClient botClient;

        public TelegramBot(string botToken)
        {
            if (String.IsNullOrEmpty(botToken))
                throw new ArgumentNullException(nameof(botToken));

            botClient = new TelegramBotClient(botToken);
        }

        public void Start(ITelegramBotHandles telegramBotHandles, Action conditionStopping)
        {
            Start(telegramBotHandles.HandleUpdateAsync, telegramBotHandles.HandleErrorAsync, conditionStopping);
        }
        public void Start(Func<ITelegramBotClient, Update, CancellationToken, Task> handleUpdateAsync, Func<ITelegramBotClient, Exception, CancellationToken, Task> handleErrorAsync, Action conditionalStopping)
        {
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            ReceiverOptions receiverOptions = new ReceiverOptions{AllowedUpdates = { }};
            botClient.StartReceiving(handleUpdateAsync, handleErrorAsync, receiverOptions, cancellationToken);
            conditionalStopping();
        }
        public ITelegramBotClient getBotClient()
        {
            return botClient;
        }
    }
}
