﻿using LibraryBot.BotBehaviors.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories.Requests
{
    internal interface IRequest
    {
        public IResponse CreateResponse();
    }
}
