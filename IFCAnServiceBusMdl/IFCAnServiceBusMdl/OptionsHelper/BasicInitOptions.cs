using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper
{
    public class BasicInitOptions : OptionsInitResponsibility
    {
        public BasicInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        public override void Handle(IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {            
            if (ifcAnServiceBusOptions.Container != null)
            {
                _endpointConfiguration.UseContainer<AutofacBuilder>(
                    customizations: c =>
                    {
                        c.ExistingLifetimeScope(
                            ifcAnServiceBusOptions.Container);
                    });
            }    
            _endpointConfiguration.EnableInstallers();
            SetSucceesorNext(new TestOrProductInitOptions(_endpointConfiguration));
            _succeesorNext.Handle(ifcAnServiceBusOptions);
        }
    }
}
