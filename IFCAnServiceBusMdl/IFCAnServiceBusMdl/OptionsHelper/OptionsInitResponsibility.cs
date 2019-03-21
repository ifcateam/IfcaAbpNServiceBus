using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBus;
using Volo.Abp.DependencyInjection;

namespace IFCAnServiceBusMdl.OptionsHelper
{
    public abstract class OptionsInitResponsibility 
    {
        protected OptionsInitResponsibility _succeesorNext;        
        protected EndpointConfiguration _endpointConfiguration;
        


        protected OptionsInitResponsibility(EndpointConfiguration endpointConfiguration)
        {
            _endpointConfiguration = endpointConfiguration;
        }

        public abstract void Handle(IFCAnServiceBusOptions ifcAnServiceBusOptions);
    
        public void SetSucceesorNext(OptionsInitResponsibility optionsResponsibility)
        {
            _succeesorNext = optionsResponsibility;
        }
    }
}

