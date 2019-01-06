using System;
using NServiceBus;

namespace EventCmdAllData
{
    public class PlaceOrderCmd : ICommand
    {
        public string OrderID { get; set; }
        public string Descript { get; set; }
    }
}
