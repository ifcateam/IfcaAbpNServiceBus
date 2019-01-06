using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventCmdAllData;
using NServiceBus;

namespace waitListClient.Subscription
{
    public class AddSeatsToWaitListCmdHandler : IHandleMessages<AddSeatsToWaitList>
    {
        public Task Handle(AddSeatsToWaitList message, IMessageHandlerContext context)
        {
            Console.WriteLine("6.已经收到等待的命令，WaitList");

            return Task.CompletedTask;
        }
    }
}
