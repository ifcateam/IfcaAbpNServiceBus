using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Sagas;

namespace SagasMdl.Modles
{
    public class SagaNotFoundHandler :
    IHandleSagaNotFound
    {
        public Task Handle(object message, IMessageProcessingContext context)
        {
            //            var sagaDisappearedMessage = new SagaDisappearedMessage();
            //            return context.Reply(sagaDisappearedMessage);
            //              这里一直找不到会一直到这里
            return Task.CompletedTask;

        }
    }

    public class SagaDisappearedMessage
    {
    }
}
