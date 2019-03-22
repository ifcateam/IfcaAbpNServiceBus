using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IFCAnServiceBusMdl.OptionsHelper.StoragePersInitOptions;
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
                FactoryCreateNextSucceesorStorage(ifcAnServiceBusOptions
                    .StoragePersistence);
                _succeesorNext.Handle(ifcAnServiceBusOptions);
            }
        }

        private void FactoryCreateNextSucceesorStorage(
            ENUM_StoragePersistence enumStorage)
        {
            switch (enumStorage)
            {
                case ENUM_StoragePersistence.Mysql:
                    SetSucceesorNext(
                        new StoragePersMySqlInitOptions(_endpointConfiguration));
                    break;
                case ENUM_StoragePersistence.Sqlserver:
                    SetSucceesorNext(
                        new StoragePersMySqlInitOptions(_endpointConfiguration));
                    break;
            }


        }
    }
}
