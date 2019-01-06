using System;
using Volo.Abp;

namespace SagaService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
               AbpApplicationFactory.Create<SagaServiceModule>(
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
