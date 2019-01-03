using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace OrderClient
{
    public class Class1 : ITransientDependency
    {
        public Class1()
        {
            Name = "test";
        }

        public string Name { get; set; }
    }
}
