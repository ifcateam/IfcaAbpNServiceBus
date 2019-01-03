using System;
using NServiceBus;

namespace ServiceBusTestDatas
{
    public class PlaceOrderCmd : ICommand
    {
        public string OrderId { get; set; }
    }
}
