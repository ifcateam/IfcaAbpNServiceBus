using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace SagaService.Subscription
{
    public class OrderSagaData : ContainSagaData
    {
        public string OrderId { get; set; }
        public bool OrderAggregateIsCommit { get; set; }
        public bool ReservationIsCommit { get; set; }
        public bool PayMentIsCommit { get; set; }
        public bool WaitListAggregateIsCommit { get; set; }
    }
}
