using System;
using System.Diagnostics;
using IFCAnServiceBusMdl.EndPoint;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace OrderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
                AbpApplicationFactory.Create<OrderClientModule>(
                    (options) =>
                    {
                        options.UseAutofac(); 

                    }))
            {

                application.Initialize();

                Console.WriteLine("Press ENTER to stop application...");

                Debug.Print(application.ServiceProvider.GetService<Class1>().Name);
                Console.ReadLine();
            }

            Console.WriteLine("Hello World!");
        }


    }
}
