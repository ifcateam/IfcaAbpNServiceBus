﻿using System;
using Volo.Abp;

namespace ReserveClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application =
               AbpApplicationFactory.Create<ReserveClientModule>(
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
