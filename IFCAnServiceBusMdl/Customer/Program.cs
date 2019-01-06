using System;
using EventCmdAllData;
using IFCAnServiceBusMdl.EndPoint;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using Volo.Abp;
using Volo.Abp.Threading;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
                AbpApplicationFactory.Create<CustomerModule>(
                    (options) =>
                    {
                        options.UseAutofac();

                    }))
            {

                application.Initialize();

                Console.WriteLine("Press ENTER to stop application...");
                Console.WriteLine("1.PlaceOrder 发出");

                //发送下单命令PlaceOrder
                var endpoint = application.ServiceProvider
                    .GetService<IIFCAEndpoint>();
                var cmd = new PlaceOrderCmd()
                {
                    Descript = "Customer 发出的命令",
                    OrderID = "order001"

                };
                AsyncHelper.RunSync(() =>
                {
                    return endpoint.Send("OrderAggregate",cmd);
                });



                Console.ReadLine();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
