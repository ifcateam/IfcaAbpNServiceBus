using System;
using Volo.Abp;

namespace PayMentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
               AbpApplicationFactory.Create<PayMentModule>(
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
