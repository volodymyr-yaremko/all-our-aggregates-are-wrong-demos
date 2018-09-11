﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NServiceBus;
using Warehouse.Data;
using Warehouse.Data.Models;
using Warehouse.Messages.Commands;

namespace Warehouse.Service.Handlers
{
    class AddItemToCartHandler : IHandleMessages<AddItemToCart>
    {
        public async Task Handle(AddItemToCart message, IMessageHandlerContext context)
        {
            using (var db = WarehouseContext.Create())
            {
                var requestAlreadyHandled = await db.ShoppingCartItems
                    .SingleOrDefaultAsync(o => o.RequestId == message.RequestId) != null;

                if (!requestAlreadyHandled)
                {
                    var stockItem = db.StockItems
                        .Where(o => o.ProductId == message.ProductId)
                        .Single();

                    db.ShoppingCartItems.Add(new ShoppingCartItem()
                    {
                        CartId = message.CartId,
                        RequestId = message.RequestId,
                        ProductId = message.ProductId,
                        Inventory = stockItem.Inventory,
                        Quantity = message.Quantity
                    });

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
