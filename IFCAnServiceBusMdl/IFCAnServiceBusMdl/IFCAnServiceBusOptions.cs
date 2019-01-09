using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace IFCAnServiceBusMdl
{
    public class IFCAnServiceBusOptions
    {
        public IFCAnServiceBusOptions()
        {
            CurrentServiceName = "DefaultClient";
           
        }

        public string CurrentServiceName { get; set; }
        public IContainer Container { get; set; }

    }
}
