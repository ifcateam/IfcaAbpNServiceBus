﻿using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper.StoragePersInitOptions
{
    public class StoragePersMsSqlInitOptions:StoragePersInitOptions
    {
        public StoragePersMsSqlInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        protected override void SqlInit(PersistenceExtensions<SqlPersistence> sqlPersistence,
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            throw new System.NotImplementedException();
        }
    }
}
