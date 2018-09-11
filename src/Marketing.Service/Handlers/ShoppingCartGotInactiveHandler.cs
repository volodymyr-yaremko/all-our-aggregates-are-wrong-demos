﻿using NServiceBus;
using Sales.Messages.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Marketing.Service.Handlers
{
    class ShoppingCartGotInactiveHandler : IHandleMessages<ShoppingCartGotInactive>
    {
        public Task Handle(ShoppingCartGotInactive message, IMessageHandlerContext context)
        {
            Console.WriteLine("Another lost customer. BAD BAD BAD!", Color.Red);

            return Task.CompletedTask;
        }
    }
}
