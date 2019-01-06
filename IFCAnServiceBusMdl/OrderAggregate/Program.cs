using System;
using EventCmdAllData;
using IFCAnServiceBusMdl.EndPoint;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using Volo.Abp;
using Volo.Abp.Threading;

namespace OrderAggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
                AbpApplicationFactory.Create<OrderAggregateModule>(
                    (options) =>
                    {
                        options.UseAutofac();

                    }))
            {

                application.Initialize();

                Console.WriteLine("Press ENTER to stop application...");
               
                Console.ReadLine();
            }
        }
    }
}
