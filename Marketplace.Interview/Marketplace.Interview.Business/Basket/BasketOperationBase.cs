﻿using System;
using System.Collections.Generic;
using System.IO;
using Marketplace.Interview.Business.Core;

namespace Marketplace.Interview.Business.Basket
{
    public abstract class BasketOperationBase
    {
        private static readonly string file = Path.Combine(Environment.GetEnvironmentVariable("temp"), "basket1.xml");

        protected Basket GetBasket()
        {
            if (!File.Exists(file))
                return new Basket {LineItems = new List<LineItem>(),};

            using (var sr = new StreamReader(file))
            {
                return SerializationHelper.DataContractDeserialize<Basket>(sr.ReadToEnd());
            }
        }

        protected void SaveBasket(Basket basket)
        {
            using (var sw = new StreamWriter(file, false))
            {
                sw.Write(SerializationHelper.DataContractSerialize(basket));
            }
        }
    }
}