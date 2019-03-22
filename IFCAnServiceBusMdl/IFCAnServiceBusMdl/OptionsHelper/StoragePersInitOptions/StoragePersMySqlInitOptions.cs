using MySql.Data.MySqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper.StoragePersInitOptions
{
    public class StoragePersMySqlInitOptions:StoragePersInitOptions
    {
        public StoragePersMySqlInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        protected override void SqlInit(
            PersistenceExtensions<SqlPersistence> sqlPersistence,
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            sqlPersistence.SqlDialect<SqlDialect.MySql>();

            sqlPersistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new MySqlConnection(ifcAnServiceBusOptions
                        .OptionPropertyForStoragePersistence.Connections);
                });
        }
    }
}
