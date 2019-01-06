using System;
using System.Diagnostics;
using Volo.Abp;

namespace waitListClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var application =
                AbpApplicationFactory.Create<waitListClientModule>(
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
