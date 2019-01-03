using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace ReservationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
                AbpApplicationFactory.Create<ReservationClientModule>(
                    (options) =>
                    {
                        options.UseAutofac();

                    }))
            {

                application.Initialize();

                Console.WriteLine("Press ENTER to stop application...");

//                Debug.Print(application.ServiceProvider.GetService<Class1>().Name);
                Console.ReadLine();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
