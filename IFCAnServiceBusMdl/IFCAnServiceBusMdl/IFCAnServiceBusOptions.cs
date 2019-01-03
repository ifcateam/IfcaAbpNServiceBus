using System;
using System.Collections.Generic;
using System.Text;

namespace IFCAnServiceBusMdl
{
    public class IFCAnServiceBusOptions
    {
        public IFCAnServiceBusOptions()
        {
            CurrentServiceName = "DefaultClient";
        }

        public string CurrentServiceName { get; set; }

    }
}
