using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NServiceBus;

namespace IFCAnServiceBusMdl.OptionsHelper
{
    public class TestOrProductInitOptions : OptionsInitResponsibility
    {


        public TestOrProductInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        public override void Handle(
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            
            #region Persistence
            if (ifcAnServiceBusOptions.TestorProduct ==
                ENUM_SERVICBUS_TESTORPRODUCT.Test)
            {
                _endpointConfiguration.EnableInstallers();
                _endpointConfiguration.UsePersistence<LearningPersistence>();
            }
            #endregion

            #region Transport
            if (ifcAnServiceBusOptions.TestorProduct ==
                ENUM_SERVICBUS_TESTORPRODUCT.Test)
            {
                var transport =
                    _endpointConfiguration.UseTransport<LearningTransport>();
                var vp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "\\TempQua");
                transport.StorageDirectory(vp);
            }
            #endregion

            if (ifcAnServiceBusOptions.TestorProduct ==
                ENUM_SERVICBUS_TESTORPRODUCT.Product)
            {
                SetSucceesorNext(
                    new LocalOrDistributionInitOptions(_endpointConfiguration));
                _succeesorNext.Handle(ifcAnServiceBusOptions);
            }
        }
    }
}
